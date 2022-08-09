using System;
using System.Collections.Generic;
using MagicNight.Models.Database.Rolls.Values;

namespace MagicNight.Models.Database.Rolls
{
    public class SetRoll
    {
        
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public List<SetRollEntry> Entries { get; set; } = new();

        public SetRoll()
        {
        }

        public SetRoll(DateTime dateTime)
        {
            DateTime = dateTime;
        }
    }
}