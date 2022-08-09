using System.Collections.Generic;
using MagicNight.Models.Scryfall;

namespace MagicNight.Misc
{
    public class ScryfallCardComparer : IEqualityComparer<ScryfallCard>
    {
        public bool Equals(ScryfallCard x, ScryfallCard y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Name == y.Name;
        }

        public int GetHashCode(ScryfallCard obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}