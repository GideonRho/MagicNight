using System;
using MagicNight.Models.Enums;

namespace MagicNight.Misc;

public static class RarityHelper
{

    public static Rarity FromString(string rarity)
    {
        foreach (var value in Enum.GetValues<Rarity>())
        {
            if (string.Equals(rarity, value.ToString(), StringComparison.InvariantCultureIgnoreCase))
                return value;
        }

        throw new ArgumentException($"{rarity} is not a valid rarity!");
    }
    
}