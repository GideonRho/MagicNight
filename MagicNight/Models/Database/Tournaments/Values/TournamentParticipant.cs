using MagicNight.Models.Database.Profiles;

namespace MagicNight.Models.Database.Tournaments.Values
{
    public class TournamentParticipant
    {
        
        public int Id { get; set; }
        
        public Tournament Tournament { get; set; }
        public Profile Profile { get; set; }

        public TournamentParticipant()
        {
        }

        public TournamentParticipant(Tournament tournament, Profile profile)
        {
            Tournament = tournament;
            Profile = profile;
        }

        public override string ToString() => Profile.Name;
    }
}