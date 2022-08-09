using System.Collections.Generic;
using MagicNight.Models.Enums;

namespace MagicNight.Misc
{
    public static class ColorsHelper
    {

        public static int Count(this Colors self)
        {
            int iCount = 0;
            
            while (self != 0)
            {
                self &= self - 1;
                iCount++;
            }
            
            return iCount;
        }

        public static IEnumerable<Colors> All()
        {
            yield return Colors.White;
            yield return Colors.Blue;
            yield return Colors.Black;
            yield return Colors.Red;
            yield return Colors.Green;
        }

        public static IEnumerable<Colors> Combinations(this Colors self, int amount)
        {
            for (int i = 0; i < 64; i++)
            {
                Colors c = (Colors) i;
                if (!self.HasFlag(c)) continue;
                if (c.Count() != amount) continue;
                yield return c;
            }
        }

    }
}