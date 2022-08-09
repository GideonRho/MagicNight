using System.Collections.Generic;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Data;

public class ColorSet
{
    
    public Colors Primary { get; set; }
    public Colors Secondary { get; set; }
    public Colors Tertiary { get; set; }

    public ColorSet(Colors primary, Colors secondary, Colors tertiary)
    {
        Primary = primary;
        Secondary = secondary;
        Tertiary = tertiary;
    }

    public IEnumerable<Colors> Combinations()
    {
        yield return Primary;
        yield return Primary | Secondary;
        yield return Primary | Secondary | Tertiary;
    }

    public Colors SecondaryCombination => Primary | Secondary;
    public Colors Combination => Primary | Secondary | Tertiary;
}