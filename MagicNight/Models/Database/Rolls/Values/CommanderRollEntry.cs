using System;
using MagicNight.Models.Data;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Database.Profiles;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Database.Rolls.Values
{
    public class CommanderRollEntry
    {
        
        public int Id { get; set; }
        public string User { get; set; }
        public Card Commander { get; set; }
        public Card Partner { get; set; }

        public CommanderRollEntry()
        {
        }

        public CommanderRollEntry(string user, CommanderPair pair)
        {
            User = user;
            Commander = pair.Card;
            Partner = pair.Partner;
        }
        
    }
}