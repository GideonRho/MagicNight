using System;
using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Database.Cards;

namespace MagicNight.Models.Data;

public class BaseDeck
{
    
    public string Id { get; set; }
    public List<Card> Cards { get; set; }

    public BaseDeck(IEnumerable<Card> cards)
    {
        Id = Guid.NewGuid().ToString();
        Cards = cards.ToList();
    }
}