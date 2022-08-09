using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Database.Sets;

namespace MagicNight.Misc;

public class FastCardStore
{
    
    private Dictionary<string, Card> Dictionary { get; }

    public FastCardStore(IEnumerable<Card> cards)
    {
        Dictionary = cards.ToDictionary(s => s.Name);
    }

    public bool Contains(string card) => Dictionary.ContainsKey(card);
    
    public Card Get(string card) 
        => Dictionary.TryGetValue(card, out var value) ? value : null;
    
}