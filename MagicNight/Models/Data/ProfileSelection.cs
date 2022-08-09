using MagicNight.Models.Database.Profiles;

namespace MagicNight.Models.Data
{
    public class ProfileSelection
    {
        
        public Profile Profile { get; set; }
        public bool IsSelected { get; set; }

        public ProfileSelection(Profile profile, bool isSelected)
        {
            Profile = profile;
            IsSelected = isSelected;
        }
    }
}