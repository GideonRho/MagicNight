using System;
using System.Collections.Generic;
using System.Linq;
using MagicNight.Misc;
using MagicNight.Models.Database.Profiles;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Data
{
    public class ProfileRoll
    {
        
        public string User { get; set; }
        public List<Colors> Colors { get; set; } = new();
        public List<CommanderPair> Commanders { get; set; } = new();

        public ProfileRoll(string user)
        {
            User = user;
        }

        public List<Colors> AssignColor(Random random, List<Colors> colors)
        {
            var viable = new List<Colors>(colors);
            List<Colors> returnList;

            foreach (var color in Colors)
                viable.Remove(color);
            
            if (viable.Count == 0)
            {
                viable = ColorsHelper.All().ToList();
                returnList = new List<Colors>(viable);
            }
            else
            {
                returnList = new List<Colors>(colors);
            }

            var i = random.Next(viable.Count);
            Colors.Add(viable[i]);
            returnList.Remove(viable[i]);

            return returnList;
        }

        public Colors Primary => Colors[0];
        
        public Colors Tertiary()
        {
            var colors = (Colors)0;
            foreach (var color in Colors)
                colors |= color;
            
            return colors;
        }
        
        public Colors Secondary()
        {
            var colors = (Colors)0;
            for (int i = 0; i < 2; i++)
                colors |= Colors[i];
            return colors;
        }
        
    }
}