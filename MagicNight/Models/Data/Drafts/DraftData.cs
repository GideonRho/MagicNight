using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MagicNight.Models.Data.Drafts;

public class DraftData
{

    public enum EState
    {
        Paused, OnGoing, Finished
    }
    
    public int RoundTime { get; set; }
    
    public List<Player> Players { get; set; }
    
    public EState State { get; set; }
    public int Timer { get; set; }

    public event Action OnChange;
    public event Action OnFinished;
    
    private Task TimerTask { get; }
    
    public DraftData(IEnumerable<Player> players, int roundTime)
    {
        Players = players.ToList();
        RoundTime = roundTime; 
        State = EState.Paused;
        Timer = 0;

        TimerTask = Task.Run(RunTimer);
    }

    private async Task RunTimer()
    {
        while (true)
        {
            await Task.Delay(1000);
            AdvanceTime();
        }
    }
    
    public void AdvanceTime()
    {
        if (State != EState.OnGoing) return;
        
        Timer++;
        if (Timer == RoundTime)
            Advance();
        else
            NotifyStateChanged();
    }

    public void Pause()
    {
        if (State != EState.OnGoing) return;
        State = EState.Paused;
        NotifyStateChanged();
    }

    public void Resume()
    {
        if (State != EState.Paused) return;
        State = EState.OnGoing;
        NotifyStateChanged();
    }

    public void Advance()
    {
        Timer = 0;

        if (IsDone)
        {
            Finish();
            return;
        }

        if (RoundIsDone)
        {
            NextPack();
            return;
        }
        
        Rotate();
    }

    private void Finish()
    {
        Players.ForEach(p => p.Finish());
        State = EState.Finished;
        NotifyFinish();
        NotifyStateChanged();
    }
    
    private void Rotate()
    {
        Players[0].Rotate();
        NotifyStateChanged();
    }

    private void NextPack()
    {
        Players.ForEach(p => p.FlipOrder());
        Players.ForEach(p => p.NextPack());
        NotifyStateChanged();
    }

    private bool RoundIsDone => Players[0].RoundIsDone;
    private bool IsDone => Players[0].IsDone;
    
    private void NotifyStateChanged() => OnChange?.Invoke();
    private void NotifyFinish() => OnFinished?.Invoke();
    
}