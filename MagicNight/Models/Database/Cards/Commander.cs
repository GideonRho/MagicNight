using System.ComponentModel.DataAnnotations.Schema;

namespace MagicNight.Models.Database.Cards
{
    public class Commander
    {
        
        public int Id { get; set; }
        
        [ForeignKey("CardName")]
        public Card Card { get; set; }
        public string CardName { get; set; }

        public Commander()
        {
        }

        public Commander(string card)
        {
            CardName = card;
        }

        public Commander(Card card)
        {
            Card = card;
        }
    }
}