using MagicNight.Models.Database.Profiles;

namespace MagicNight.Models.Database.Tournaments
{
    public class Match
    {

        public int Id { get; set; }
        
        public Profile PlayerA { get; set; }
        public Profile PlayerB { get; set; }

        public int WinsA { get; set; }
        public int WinsB { get; set; }
        public int Winner { get; set; }

        public Group Group { get; set; }

        public Match()
        {
        }

        public Match(Group group, Profile playerA, Profile playerB, int winner)
        {
            Group = group;
            PlayerA = playerA;
            PlayerB = playerB;
            Winner = winner;
            if (Winner == 1) WinsA = 2;
            if (Winner == 2) WinsB = 2;
        }

        public Profile WinnerProfile()
        {
            if (Winner == 1) return PlayerA;
            if (Winner == 2) return PlayerB;
            return null;
        }

        public Profile LoserProfiler()
        {
            if (Winner == 1) return PlayerB;
            if (Winner == 2) return PlayerA;
            return null;
        }

        public Profile Opponent(Profile player)
        {
            if (PlayerA == player) return PlayerB;
            if (PlayerB == player) return PlayerA;
            return null;
        }

    }
}