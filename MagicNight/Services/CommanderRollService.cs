using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Data;
using MagicNight.Models.Data.Rolls;
using MagicNight.Models.Enums;
using MagicNight.Utils;

namespace MagicNight.Services;

public class CommanderRollService
{

    private GenerateService GenerateService { get; }

    public CommanderRollService(GenerateService generateService)
    {
        GenerateService = generateService;
    }
    
    public CommanderRollLobbyData Roll(Lobby lobby) => new(Roll(lobby.Users));

    public IEnumerable<CommanderRoll> Roll(List<string> users)
    {
        var combinations = ColorUtils.RandomizedCombination(users.Count).ToList();
        for (int i = 0; i < users.Count; i++)
            yield return new CommanderRoll(users[i], combinations[i], Roll(combinations[i]));
    }

    public IEnumerable<CommanderRollEntry> Roll(ColorSet set)
    {
        
        foreach (var combination in set.Combinations())
        {
            var c = GenerateService.RandomCommander(combination).Result;
            var p = GenerateService.Partner(c, set.Combination).Result;
            yield return new CommanderRollEntry(c, p);
        }
        
        var commander = GenerateService.RandomCommanderWild(set).Result;
        var partner = GenerateService.Partner(commander, set.Combination).Result;
        yield return new CommanderRollEntry(commander, partner);
    }

}