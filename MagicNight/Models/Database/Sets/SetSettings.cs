using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicNight.Models.Database.Sets
{
    public class SetSettings
    {
        
        [Key]
        public string Code { get; set; }
        public bool CanRoll { get; set; }

        [ForeignKey("Code")]
        public Set Set { get; set; }
        
        public SetSettings()
        {
        }

        public SetSettings(Set set)
        {
            Set = set;
        }
    }
}