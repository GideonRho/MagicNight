using MagicNight.Models.Database.Decks;
using MagicNight.Models.Database.Profiles;
using MagicNight.Models.Database.Sets;

namespace MagicNight.Models.Database.Rolls.Values
{
    public class SetRollEntry
    {
        
        public int Id { get; set; }
        
        public SetRoll SetRoll { get; set; }
        public Profile Profile { get; set; }
        
        public Set Set { get; set; }
        public Deck Deck { get; set; }

        public SetRollEntry()
        {
        }

        public SetRollEntry(SetRoll setRoll, Profile profile)
        {
            SetRoll = setRoll;
            Profile = profile;
        }
    }
}