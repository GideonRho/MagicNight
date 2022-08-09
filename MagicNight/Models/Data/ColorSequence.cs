using System;
using System.Collections.Generic;
using System.Linq;
using MagicNight.Misc;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Data;

public class ColorSequence
{
    
    public List<Colors> Colors { get; }

    public ColorSequence(List<Colors> colors)
    {
        Colors = colors;
    }

    public bool Overlap(ColorSequence other)
    {
        return Colors.Where((t, i) => t == other.Colors[i]).Any();
    }
    
    public Colors this[int index] => Colors[index];

    public static ColorSequence Random()
    {
        var random = new Random();
        var array = ColorsHelper.All().ToArray();
        var n = array.Length;
        while (n > 1) 
        {
            var k = random.Next(n--);
            (array[n], array[k]) = (array[k], array[n]);
        }

        return new ColorSequence(array.ToList());
    }

}