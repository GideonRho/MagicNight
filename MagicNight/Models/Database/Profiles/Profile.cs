using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagicNight.Models.Database.Profiles
{
    public class Profile
    {
        
        [Key]
        public string Name { get; set; }
        public bool IsDisabled { get; set; }

        public Profile()
        {
        }

        public Profile(string name)
        {
            Name = name;
        }

        private sealed class NameEqualityComparer : IEqualityComparer<Profile>
        {
            public bool Equals(Profile x, Profile y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Name == y.Name;
            }

            public int GetHashCode(Profile obj)
            {
                return (obj.Name != null ? obj.Name.GetHashCode() : 0);
            }
        }

        public static IEqualityComparer<Profile> NameComparer { get; } = new NameEqualityComparer();
        
        public static bool operator ==(Profile a, Profile b) => a?.Name == b?.Name;
        public static bool operator !=(Profile a, Profile b) => !(a == b);

        public override string ToString() => Name;
    }
}