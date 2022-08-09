using System;
using System.Collections.Generic;
using MagicNight.Helpers;

namespace MagicNight.Models.Data.Tournaments;

public class ResultEntry
{
    private int _winsA;
    private int _winsB;

    public string SeedA { get; set; }
    public string SeedB { get; set; }

    public int WinsA
    {
        get => _winsA;
        set
        {
            _winsA = value;
            NotifyStateChanged();
        }
    }

    public int WinsB
    {
        get => _winsB;
        set
        {
            _winsB = value;
            NotifyStateChanged();
        }
    }

    public event Action OnChange;
    
    public ResultEntry(string seedA, string seedB)
    {
        SeedA = seedA;
        SeedB = seedB;
    }

    public IEnumerable<string> Players()
    {
        yield return SeedA;
        yield return SeedB;
    }

    public int MatchWins(string player)
    {
        if (SeedA == player && _winsA > _winsB) return 1;
        if (SeedB == player && _winsB > _winsA) return 1;
        return 0;
    }
    
    public int MatchLoses(string player)
    {
        if (SeedA == player && _winsA < _winsB) return 1;
        if (SeedB == player && _winsB < _winsA) return 1;
        return 0;
    }
    
    public int Wins(string player)
    {
        if (SeedA == player) return _winsA;
        if (SeedB == player) return _winsB;
        return 0;
    }
    
    public int Loses(string player)
    {
        if (SeedA == player) return _winsB;
        if (SeedB == player) return _winsA;
        return 0;
    }
    
    private void NotifyStateChanged() => OnChange?.Invoke();
    
    public static IEnumerable<ResultEntry> RoundRobin(List<string> users, int round)
    {
        yield return new ResultEntry(users[0], users[LowerIndex(0, round, users.Count)]); 
        for (int i = 1; i < users.Count / 2; i++)
        {
            yield return new ResultEntry(
                users[UpperIndex(i, round, users.Count)],
                users[LowerIndex(i, round, users.Count)]);
        }
    }

    private static int UpperIndex(int i, int round, int length) 
        => IntHelper.Modulo(i - round -1, length -1) +1;
    private static int LowerIndex(int i, int round, int length) 
        => IntHelper.Modulo(length - i - round -1, length -1) +1;

}