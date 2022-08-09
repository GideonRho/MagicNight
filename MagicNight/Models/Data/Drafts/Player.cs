using System;
using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Database.Cards;

namespace MagicNight.Models.Data.Drafts;

public class Player
{
    
    public string Name { get; set; }
    
    public Player Next { get; set; }
    public Player Previous { get; set; }

    public Pack Current { get; set; }
    public List<Pack> Packs { get; set; }

    public List<Card> Picks { get; set; } = new();
    public bool HasPicked { get; set; }

    public BaseDeck Deck { get; set; }
    
    public event Action OnChange;
    
    public Player(string name, IEnumerable<Pack> packs)
    {
        Name = name;
        Packs = packs.ToList();
        NextPack();
    }

    public void NextPack()
    {
        if (Current != null) AutoPick();
        HasPicked = false;
        Current = Packs[0];
        Packs.Remove(Current);
    }

    public void FlipOrder()
    {
        (Next, Previous) = (Previous, Next);
    }

    public void Rotate() => Next.Rotate(Current, Next);
    
    private void Rotate(Pack pack, Player start)
    {
        AutoPick();
        HasPicked = false;

        if (start != Next)
            Next.Rotate(Current, start);
        
        Current = pack;
    }

    public void Finish()
    {
        AutoPick();
        Deck = new BaseDeck(Picks);
    }
    
    public void AutoPick()
    {
        if (HasPicked) return;
        Pick(Current.Cards[0], false);
    }
    
    public void Pick(Card card, bool notify = true)
    {
        if (HasPicked) return;
        HasPicked = true;
        Current.Cards.Remove(card);
        Picks.Add(card);
        if (notify)
            NotifyStateChanged();
    }

    public bool RoundIsDone => Current.Cards.Count == 0 || Current.Cards.Count == 1 && HasPicked == false;
    public bool IsDone => RoundIsDone && Packs.Count == 0;
    
    private void NotifyStateChanged() => OnChange?.Invoke();
}