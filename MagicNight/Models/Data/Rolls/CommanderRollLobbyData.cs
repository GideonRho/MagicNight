using System.Collections.Generic;
using System.Linq;

namespace MagicNight.Models.Data.Rolls;

public class CommanderRollLobbyData
{
    
    public List<CommanderRoll> Rolls { get; set; }

    public CommanderRollLobbyData(IEnumerable<CommanderRoll> data)
    {
        Rolls = data.ToList();
    }
}