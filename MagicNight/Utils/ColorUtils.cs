using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Data;

namespace MagicNight.Utils;

public static class ColorUtils
{

    public static IEnumerable<ColorSet> RandomizedCombination(int size)
    {
        for (int mod = 0; mod <= (size -1) / 5; mod++)
        {
            var primary = Sequences().First();
            var secondary = Sequences().First(s => !s.Overlap(primary));
            var tertiary = Sequences().First(s => !s.Overlap(primary) && !s.Overlap(secondary));
        
            for (int i = 0; i < size - mod * 5 && i < 5; i++)
                yield return new ColorSet(primary[i], secondary[i], tertiary[i]);
        }
    }
    
    public static IEnumerable<ColorSequence> Sequences()
    {
        while(true) yield return ColorSequence.Random();
    }

}