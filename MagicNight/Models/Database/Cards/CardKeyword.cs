namespace MagicNight.Models.Database.Cards
{
    public class CardKeyword
    {
        
        public int Id { get; set; }
        
        public Card Card { get; set; }
        public string Name { get; set; }

        public CardKeyword()
        {
        }

        public CardKeyword(Card card, string name)
        {
            Card = card;
            Name = name.ToLower().Replace(" ", "");
        }
    }
}