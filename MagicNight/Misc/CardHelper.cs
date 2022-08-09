using System;
using System.Collections.Generic;
using MagicNight.Models.Enums;

namespace MagicNight.Misc
{
    public static class CardHelper
    {

        public static IEnumerable<string> CardTypesFromString(string type)
        {
            var split = type.Split(' ');
            foreach (var s in split)
            {
                if (s is "—" or "//") continue;
                yield return s.ToLower();
            }
        }

        public static CardTypes? GetCardType(string type)
        {
            foreach (var value in Enum.GetValues<CardTypes>())
            {
                if (type.Contains(value.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    return value;
            }
            return null;
        }
        
        public static Colors ColorFromString(string color)
        {
            return color switch
            {
                "W" => Colors.White,
                "R" => Colors.Red,
                "U" => Colors.Blue,
                "B" => Colors.Black,
                "G" => Colors.Green,
                _ => Colors.Colorless
            };
        }

        public static string DbString(this KeyWord self) => self.ToString().ToLower();

    }
}