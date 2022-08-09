using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Database.Sets;

namespace MagicNight.Misc;

public class FastSetStore
{
    
    private Dictionary<string, Set> Dictionary { get; }

    public FastSetStore(IEnumerable<Set> sets)
    {
        Dictionary = sets.ToDictionary(s => s.Code);
    }

    public bool Contains(string set) => Dictionary.ContainsKey(set.ToUpper());
    
    public Set Get(string set) 
        => Dictionary.TryGetValue(set.ToUpper(), out var value) ? value : null;
}