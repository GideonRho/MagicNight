using System.Collections.Generic;
using MagicNight.Models.Database.Cards;

namespace MagicNight.Models.Data.Drafts;

public class Pack
{
    
    public List<Card> Cards { get; set; }

    public Pack(List<Card> cards)
    {
        Cards = cards;
    }
}