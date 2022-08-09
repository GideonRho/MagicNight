using System;
using System.Collections.Generic;
using System.Linq;
using MagicNight.Misc;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Filters
{
    public class ColorFilter
    {
        
        public bool White { get; set; }
        public bool Blue { get; set; }
        public bool Black { get; set; }
        public bool Green { get; set; }
        public bool Red { get; set; }

        public ColorFilter()
        {
        }

        public ColorFilter(Colors colors)
        {
            if (colors.HasFlag(Colors.White)) White = true;
            if (colors.HasFlag(Colors.Blue)) Blue = true;
            if (colors.HasFlag(Colors.Black)) Black = true;
            if (colors.HasFlag(Colors.Green)) Green = true;
            if (colors.HasFlag(Colors.Red)) Red = true;
        }

        public int TotalColors()
        {
            int c = 0;
            if (White) c++;
            if (Blue) c++;
            if (Black) c++;
            if (Green) c++;
            if (Red) c++;
            return c;
        }

        public Colors Flags()
        {
            Colors c = 0;
            if (White) c |= Colors.White;
            if (Blue) c |= Colors.Blue;
            if (Black) c |= Colors.Black;
            if (Green) c |= Colors.Green;
            if (Red) c |= Colors.Red;
            return c;
        }

        public IEnumerable<Colors> ColorCombinations()
        {
            for (int i = 0; i < 64; i++)
            {
                Colors c = (Colors) i;
                if (c.HasFlag(Colors.Colorless)) continue;
                if (c.Count() != 2) continue;
                if (IsValidCombination(c)) yield return c;
            }
        }
        
        public bool IsValidCombination(Colors flags)
        {
            return Enum.GetValues<Colors>().All(c => HasColor(c) || !flags.HasFlag(c));
        }

        public bool HasColor(Colors color) => color switch
        {
            Colors.Colorless => true,
            Colors.White => White,
            Colors.Blue => Blue,
            Colors.Black => Black,
            Colors.Red => Red,
            Colors.Green => Green,
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
        };
        
    }
}