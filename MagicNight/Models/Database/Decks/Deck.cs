using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Database.Decks.Values;
using MagicNight.Models.Database.Profiles;

namespace MagicNight.Models.Database.Decks
{
    public class Deck
    {

        public enum EType
        {
            Basic, Tournament, Roll, Draft
        }
        
        public int Id { get; set; }
        public EType Type { get; set; }
        public Profile Owner { get; set; }
        public string Name { get; set; }

        public List<DeckCard> Cards { get; set; } = new();

        public Deck()
        {
        }

        public Deck(EType type, Profile owner, string name)
        {
            Type = type;
            Owner = owner;
            Name = name;
        }

        public Deck(EType type, Profile owner, string name, IEnumerable<Card> cards) 
            : this(type, owner, name)
        {
            Cards = cards.Select(c => new DeckCard(this, c)).ToList();
        }

    }
}