using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Database.Tournaments.Values;

namespace MagicNight.Models.Database.Tournaments
{
    public class Group
    {
        
        public int Id { get; set; }
        
        public List<GroupEntry> Entries { get; set; }
        public List<Match> Matches { get; set; }

        public void UpdateEntries()
        {
            foreach (var entry in Entries)
            {
                entry.Wins = Matches.Count(m => m.WinnerProfile() == entry.Profile);
                entry.Loses = Matches.Count(m => m.LoserProfiler() == entry.Profile);
            }

            foreach (var entry in Entries)
            {
                entry.Buchholz = Matches
                    .Select(m => m.Opponent(entry.Profile))
                    .Where(p => p != null)
                    .Select(p => Entries.First(e => e.Profile == p))
                    .Sum(e => e.Wins);
            }
            
            UpdateRanking();
        }
        
        public void UpdateRanking()
        {
            Entries = Entries.OrderByDescending(e => e.Score).ToList();
            for (int i = 0; i < Entries.Count; i++)
                Entries[i].Rank = i + 1;
        }
        
    }
}