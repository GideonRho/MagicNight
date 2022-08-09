using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicNight.Models.Data.Tournaments;

public class TournamentData
{

    public enum EType
    {
        Swizz, SingleElimination, DoubleElimination, RoundRobin
    }
    
    public EType Type { get; set; }
    
    public Bracket Bracket { get; set; }
    public List<Round> Rounds { get; set; }

    public event Action OnChange;
    
    public TournamentData(EType type, List<Round> rounds)
    {
        Type = type;
        Rounds = rounds;
        rounds.ForEach(r => r.OnChange += NotifyStateChanged);
    }

    public TournamentData(EType type, Bracket bracket)
    {
        Type = type;
        Bracket = bracket;
    }

    public static TournamentData RoundRobin(List<string> users) =>
        new(EType.RoundRobin, Round.RoundRobin(users).ToList());
    
    private void NotifyStateChanged() => OnChange?.Invoke();
    
}