using System.ComponentModel.DataAnnotations.Schema;
using MagicNight.Models.Database.Decks;
using MagicNight.Models.Database.Profiles;

namespace MagicNight.Models.Database.Drafts.Values
{
    public class DraftProfile
    {
        
        public int Id { get; set; }
        public Draft Draft { get; set; }
        public Profile Profile { get; set; }
        public Profile Next { get; set; }
        public Profile Previous { get; set; }

        public int? DeckId { get; set; }
        [ForeignKey("DeckId")]
        public Deck Deck { get; set; }
        
        public DraftProfile()
        {
        }

        public DraftProfile(Draft draft, Profile profile, Profile next, Profile previous)
        {
            Draft = draft;
            Profile = profile;
            Next = next;
            Previous = previous;
        }

        public Profile NextProfile(int rotation)
            => rotation % 2 == 0 ? Next : Previous;

    }
}