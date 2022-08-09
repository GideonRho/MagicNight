using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Database.Drafts.Values;
using MagicNight.Models.Database.Profiles;

namespace MagicNight.Models.Database.Drafts
{
    public class DraftPack
    {
        
        public int Id { get; set; }
        public int Rotation { get; set; }
        public Draft Draft { get; set; }
        public DraftProfile Profile { get; set; }
        public bool IsPicked { get; set; }
        
        public List<DraftPackCard> Cards { get; set; }

        public DraftPack()
        {
        }

        public DraftPack(Draft draft, int rotation, DraftProfile profile, IEnumerable<string> cards)
        {
            Draft = draft;
            Rotation = rotation;
            Profile = profile;
            Cards = cards
                .Select(n => new DraftPackCard(this, n))
                .ToList();
        }

        public bool AllPicked() => Cards.All(c => c.Profile != null);

    }
}