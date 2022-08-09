using System.Collections.Generic;

namespace MagicNight.Models.Data;

public class Lobby
{

    public enum EType
    {
        None, Commander, Set, Draft, Tournament
    }
    
    public string Key { get; }
    public EType Type { get; }
    public bool IsFinished { get; set; }
    public List<string> Users { get; } = new();

    public Lobby(string key, EType type)
    {
        Key = key;
        Type = type;
    }
}