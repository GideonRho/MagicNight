using MagicNight.Models.Database.Sets;

namespace MagicNight.Models.Data.Drafts
{
    public class PackType
    {
        
        public Set Set { get; set; }
        public string Text { get; set; }

        public PackType()
        {
        }

        public PackType(Set set)
        {
            Set = set;
        }

        public override string ToString() => $"{Set}";
    }
}