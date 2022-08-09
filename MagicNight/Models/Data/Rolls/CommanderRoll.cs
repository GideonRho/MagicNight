using System.Collections.Generic;
using System.Linq;

namespace MagicNight.Models.Data.Rolls;

public class CommanderRoll
{
    
    public string User { get; set; }
    public ColorSet ColorSet { get; }
    public List<CommanderRollEntry> Entries { get; set; }

    public CommanderRoll(string user, ColorSet colorSet, IEnumerable<CommanderRollEntry> entries)
    {
        User = user;
        ColorSet = colorSet;
        Entries = entries.ToList();
    }
}