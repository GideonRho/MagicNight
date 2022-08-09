using System;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Misc;
using MagicNight.Models.Data;
using MagicNight.Models.Data.Drafts;
using MagicNight.Models.Data.Rolls;
using MagicNight.Models.Data.Tournaments;
using MagicNight.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MagicNight.Logic;

public class LobbyInstance
{
    
    private LobbyService Service { get; }
    
    public Lobby Lobby { get;}
    
    public CommanderRollLobbyData CommanderData { get; set; }
    public TournamentData TournamentData { get; set; }
    public CreateDraftData CreateDraftData { get; set; }
    public DraftData DraftData { get; set; }

    public event Action OnChange;

    public LobbyInstance(LobbyService service, string key, Lobby.EType type)
    {
        Service = service;
        Lobby = new Lobby(key, type);
        if (type == Lobby.EType.Draft) CreateDraftData = new CreateDraftData();
    }

    private async void SaveDraftDecks()
    {

        using var scope = Service.ServiceProvider.CreateScope();
        var downloadService = scope.ServiceProvider.GetRequiredService<DownloadService>();
        
        foreach (var player in DraftData.Players) await downloadService.Save(player.Deck);

    }
    
    public void Add(string user)
    {
        if (Lobby.Users.Contains(user)) return;
        Lobby.Users.Add(user);
        NotifyStateChanged();
    }

    public async Task Finish()
    {
        if (Lobby.IsFinished) return;
        Lobby.IsFinished = true;
        
        if(Lobby.Type == Lobby.EType.Commander) await FinishCommanderRoll();
        if (Lobby.Type == Lobby.EType.Tournament) await FinishTournament();
        if (Lobby.Type == Lobby.EType.Draft) await FinishDraft();
        
        NotifyStateChanged();
    }

    public void Reroll(string user)
    {
        CommanderData?.Rolls.Where(r => r.User == user)
            .ForEach(Reroll);
    }

    private void Reroll(CommanderRoll roll)
    {
        using var scope = Service.ServiceProvider.CreateScope();
        var rollService = scope.ServiceProvider.GetRequiredService<CommanderRollService>();

        roll.Entries = rollService.Roll(roll.ColorSet).ToList();
        NotifyStateChanged();

    }

    private async Task FinishDraft()
    {
        using var scope = Service.ServiceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<DraftService>();

        DraftData = service.Create(this);
        DraftData.OnFinished += SaveDraftDecks;
    }
    
    private async Task FinishTournament()
    {
        using var scope = Service.ServiceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<TournamentService>();

        TournamentData = await service.Create(Lobby);
    }
    
    private async Task FinishCommanderRoll()
    {
        using var scope = Service.ServiceProvider.CreateScope();
        var rollService = scope.ServiceProvider.GetRequiredService<CommanderRollService>();

        CommanderData = rollService.Roll(Lobby);

    }
    
    private void NotifyStateChanged() => OnChange?.Invoke();
    
}