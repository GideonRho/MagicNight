using MagicNight.Models.Database.Cards;

namespace MagicNight.Models.Data.Rolls;

public class CommanderRollEntry
{
    
    public Card Commander { get; set; }
    public Card Partner { get; set; }

    public CommanderRollEntry(Card commander)
    {
        Commander = commander;
    }

    public CommanderRollEntry(Card commander, Card partner)
    {
        Commander = commander;
        Partner = partner;
    }
}