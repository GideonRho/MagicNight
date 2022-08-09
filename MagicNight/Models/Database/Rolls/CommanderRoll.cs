using System;
using System.Collections.Generic;
using System.Linq;
using MagicNight.Misc;
using MagicNight.Models.Data;
using MagicNight.Models.Database.Profiles;
using MagicNight.Models.Database.Rolls.Values;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Database.Rolls
{
    public class CommanderRoll
    {
        
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        public List<CommanderRollEntry> Entries { get; set; } = new();

        public CommanderRoll()
        {
        }
        
        public CommanderRoll(IEnumerable<ProfileRoll> data)
        {
            Entries = data
                .SelectMany(d => d.Commanders, (p, c) 
                    => new CommanderRollEntry(p.User, c))
                .ToList();
        }

        public Colors GetColors(string user)
        {
            var result = Colors.Colorless;
            int count = 0;
            
            foreach (var entry in ProfileEntries(user))
            {
                int c = entry.Commander.Colors.Count();
                if (c >= count)
                {
                    count = c;
                    result = entry.Commander.Colors;
                }
            }
            
            return result;
        }
        
        public IEnumerable<string> Users() => Entries.Select(e => e.User).Distinct();

        public IEnumerable<CommanderRollEntry> ProfileEntries(string user) =>
            Entries.Where(e => e.User == user);

    }
}