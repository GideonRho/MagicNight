using MagicNight.Models.Database.Cards;

namespace MagicNight.Models.Data
{
    public class CardRender
    {
        
        public Card Card { get; set; }
        public bool Excluded { get; set; }

        public CardRender(Card card, bool excluded)
        {
            Card = card;
            Excluded = excluded;
        }

        public string CssClass()
        {
            if (Excluded) return "excludedCard";
            return "";
        }
        
    }
}