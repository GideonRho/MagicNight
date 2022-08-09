using System.Collections.Generic;
using System.Linq;

namespace MagicNight.Models.Data.Tournaments;

public class StandingEntry
{
    
    public string Name { get; set; }
    public int Wins { get; set; }
    public int Loses { get; set; }
    public int Points { get; set; }
    public int Buchholz { get; set; }

    private StandingEntry(string name, IReadOnlyCollection<ResultEntry> results)
    {
        Name = name;
        Wins = results.Sum(r => r.Wins(Name));
        Loses = results.Sum(r => r.Loses(Name));
        Points = results.Sum(r => r.MatchWins(Name));
    }

    public int OrderIndex => Points << 16 + Buchholz << 8 + Points; 
    
    public static IEnumerable<StandingEntry> ForRounds(IEnumerable<Round> rounds)
    {
        var results = rounds.SelectMany(r => r.Entries).ToList();
        var players = results
            .SelectMany(e => e.Players())
            .Distinct();

        return players.Select(p => new StandingEntry(p, results));
    }

}