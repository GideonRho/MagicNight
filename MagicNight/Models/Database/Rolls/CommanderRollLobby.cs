using System.Collections.Generic;
using MagicNight.Models.Database.Rolls.Values;

namespace MagicNight.Models.Database.Rolls;

public class CommanderRollLobby
{
    
    public int Id { get; set; }
    public string Guid { get; set; }
    public CommanderRoll Roll { get; set; }
    
    public List<CommanderRollLobbyEntry> Entires { get; set; }
    
}