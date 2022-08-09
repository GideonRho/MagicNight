namespace MagicNight.Models.Database.Cards
{
    public class CardSynergy
    {
        public int Id { get; set; }
        
        public Card Card { get; set; }
        public string Type { get; set; }

        public CardSynergy()
        {
        }

        public CardSynergy(Card card, string type)
        {
            Card = card;
            Type = type;
        }
    }
}