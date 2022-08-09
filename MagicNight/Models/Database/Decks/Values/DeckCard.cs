using System.ComponentModel.DataAnnotations.Schema;
using MagicNight.Models.Database.Cards;

namespace MagicNight.Models.Database.Decks.Values
{
    public class DeckCard
    {
        
        public int Id { get; set; }

        public Deck Deck { get; set; }
        
        public string CardName { get; set; }
        [ForeignKey("CardName")]
        public Card Card { get; set; }

        public DeckCard()
        {
        }

        public DeckCard(Deck deck, Card card)
        {
            Deck = deck;
            Card = card;
        }

        public DeckCard(Deck deck, string cardName)
        {
            CardName = cardName;
            Deck = deck;
        }
    }
}