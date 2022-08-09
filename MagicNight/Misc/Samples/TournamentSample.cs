using System;
using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Database.Profiles;
using MagicNight.Models.Database.Tournaments;
using MagicNight.Models.Database.Tournaments.Values;

namespace MagicNight.Misc.Samples
{
    public class TournamentSample
    {

        public List<Profile> Profiles { get; } = new();
        public Group Group { get; }

        public TournamentSample()
        {
            Profiles.Add(new Profile("Chandra"));
            Profiles.Add(new Profile("Gideon"));
            Profiles.Add(new Profile("Oko"));
            Profiles.Add(new Profile("Teferi"));
            Profiles.Add(new Profile("Ugin"));
            Profiles.Add(new Profile("Bolas"));

            Random random = new ();
            Group = new Group();
            Group.Entries = Profiles
                .Select(p => new GroupEntry(p, Group))
                .ToList();

            Group.Matches = new List<Match>();
            for (int i = 0; i < Profiles.Count; i++)
            {
                for (int j = i+1; j < Profiles.Count; j++)
                {
                    Group.Matches.Add(new Match(Group, Profiles[i], Profiles[j], random.Next(1, 3)));
                }
            }

            Group.UpdateEntries();
        }

    }
}