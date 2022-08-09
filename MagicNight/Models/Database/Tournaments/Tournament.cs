using System.Collections.Generic;
using MagicNight.Models.Database.Tournaments.Values;

namespace MagicNight.Models.Database.Tournaments
{
    public class Tournament
    {

        public enum EType
        {
            Custom
        }

        public enum EState
        {
            Creating, Started, Finished
        }
        
        public int Id { get; set; }
        public EType Type { get; set; }
        public EState State { get; set; }
        public string Name { get; set; }
        
        public Group Group { get; set; }
        
        public List<TournamentParticipant> Participants { get; set; }

    }
}