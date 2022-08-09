using System.Collections.Generic;
using MagicNight.Models.Database.Cards;

namespace MagicNight.Misc
{
    public class MinorTypeComparer : IEqualityComparer<CardMinorType>
    {
        public bool Equals(CardMinorType x, CardMinorType y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Type == y.Type;
        }

        public int GetHashCode(CardMinorType obj)
        {
            return obj.Type.GetHashCode();
        }
    }
}