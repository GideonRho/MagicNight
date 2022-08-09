using System.ComponentModel.DataAnnotations.Schema;
using MagicNight.Models.Database.Profiles;

namespace MagicNight.Models.Database.Tournaments.Values
{
    public class GroupEntry
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        [ForeignKey("Name")]
        public Profile Profile { get; set; }
        public Group Group { get; set; }
        
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Buchholz { get; set; }

        public GroupEntry()
        {
        }

        public GroupEntry(Profile profile, Group @group)
        {
            Profile = profile;
            Group = @group;
            Name = profile.Name;
        }

        public int Score => (Wins << 16) + Buchholz;

    }
}