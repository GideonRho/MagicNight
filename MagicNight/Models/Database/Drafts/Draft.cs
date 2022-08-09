using System;
using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Database.Drafts.Values;
using MagicNight.Models.Database.Profiles;

namespace MagicNight.Models.Database.Drafts
{
    public class Draft
    {

        public enum EState
        {
            Paused, Ongoing, Finished
        }
        
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public EState State { get; set; }
        public int Rotation { get; set; }
        public int Timer { get; set; }
        public int PickTime { get; set; }

        public List<DraftPack> Packs { get; set; } = new();
        public List<DraftProfile> Profiles { get; set; } = new();

        public Draft()
        {
        }

        public Draft(int pickTime)
        {
            PickTime = pickTime;
        }

        public bool AllPicked()
            => Packs.Where(p => p.Rotation == Rotation)
                .All(p => p.AllPicked());
        
        public DraftProfile GetDraftProfile(Profile profile)
            => Profiles.FirstOrDefault(p => p.Profile == profile);
        
        public IEnumerable<DraftPackCard> PickableCards(Profile profile)
            => Packs
                .Where(p => p.Profile.Profile == profile)
                .Where(p => p.Rotation == Rotation)
                .SelectMany(p => p.Cards)
                .Where(c => c.Profile == null);

        public IEnumerable<DraftPackCard> PickedCards(Profile profile)
            => Packs
                .SelectMany(p => p.Cards)
                .Where(c => c.Profile == profile);

    }
}