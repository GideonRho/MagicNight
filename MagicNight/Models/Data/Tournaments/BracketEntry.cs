namespace MagicNight.Models.Data.Tournaments;

public class BracketEntry
{
    
    public ResultEntry Result { get; set; }
    
    public BracketEntry WinnerEntry { get; set; }
    public BracketEntry LoserEntry { get; set; }
    
}