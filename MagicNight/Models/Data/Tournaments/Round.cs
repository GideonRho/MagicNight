using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicNight.Models.Data.Tournaments;

public class Round
{
    
    public List<ResultEntry> Entries { get; set; }

    public event Action OnChange;
    
    public Round(List<ResultEntry> entries)
    {
        Entries = entries;
        Entries.ForEach(e => e.OnChange += NotifyStateChanged);
    }

    public static IEnumerable<Round> RoundRobin(List<string> users)
    {
        return Enumerable.Range(0, users.Count - 1)
            .Select(r => new Round(ResultEntry.RoundRobin(users, r).ToList()));
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
    
}