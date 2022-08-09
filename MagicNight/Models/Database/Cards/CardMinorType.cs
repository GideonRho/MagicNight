namespace MagicNight.Models.Database.Cards
{
    public class CardMinorType
    {
        
        public int Id { get; set; }
        
        public Card Card { get; set; }
        public string Type { get; set; }

        public CardMinorType()
        {
        }

        public CardMinorType(Card card, string type)
        {
            Card = card;
            Type = type;
        }
    }
}