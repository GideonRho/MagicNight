using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Data;
using MagicNight.Logic;
using MagicNight.Models.Database.Drafts;
using MagicNight.Models.Database.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace MagicNight.Services;

public class LiveDraftService
{

    private IServiceProvider ServiceProvider { get; }
    
    private ConcurrentDictionary<int, DraftInstance> Instances { get; } = new();

    public LiveDraftService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        var task = RunTicks();
    }

    private async Task RunTicks()
    {
        while (true)
        {
            await Task.Delay(1000);
            foreach (var instance in Instances.Values)
                await OnTick(instance);
        }
    }

    private async Task OnTick(DraftInstance instance)
    {
        if (instance.Draft.State == Draft.EState.Ongoing && !instance.AllConnected())
            instance.Pause();
        
        if (instance.Draft.State == Draft.EState.Ongoing)
            instance.Advance();
        
        if (instance.Draft.State == Draft.EState.Finished && instance.IsFinished == false)
            await FinalizeDraft(instance);
    }
    
    public DraftInstance Access(int draftId, Profile profile)
    {
        var instance = Instances.GetOrAdd(draftId, (i) => Load(i).Result);
        instance.ActiveProfiles.Add(profile);
        return instance;
    }

    private async Task<DraftInstance> Load(int draftId)
    {
        using var scope = ServiceProvider.CreateScope();
        var draftService = scope.ServiceProvider.GetRequiredService<DraftService>();
        var draft = await draftService.Get(draftId);
        return new DraftInstance(draft);
    }
    
    private async Task FinalizeDraft(DraftInstance instance)
    {
        instance.AssignDecks();
        
        using var scope = ServiceProvider.CreateScope();
        var database = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        var deckService = scope.ServiceProvider.GetRequiredService<DeckService>();

        database.Update(instance.Draft);
        await database.SaveChangesAsync();
        
        foreach (var profile in instance.Draft.Profiles)
            await deckService.Save(profile.Deck);
        
    }
    
}