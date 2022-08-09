using System.ComponentModel.DataAnnotations.Schema;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Database.Profiles;

namespace MagicNight.Models.Database.Drafts.Values
{
    public class DraftPackCard
    {
        
        public int Id { get; set; }
        public DraftPack Pack { get; set; }
        public Profile Profile { get; set; }
        
        public string CardName { get; set; }
        [ForeignKey("CardName")]
        public Card Card { get; set; }

        public DraftPackCard()
        {
        }

        public DraftPackCard(DraftPack pack, string cardName)
        {
            Pack = pack;
            CardName = cardName;
        }
    }
}