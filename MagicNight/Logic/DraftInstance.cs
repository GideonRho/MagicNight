using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Models.Database.Decks;
using MagicNight.Models.Database.Drafts;
using MagicNight.Models.Database.Drafts.Values;
using MagicNight.Models.Database.Profiles;

namespace MagicNight.Logic;

public class DraftInstance
{
    
    public Draft Draft { get; }
    public bool IsFinished { get; set; }

    public List<Profile> ActiveProfiles { get; } = new();

    public DraftInstance(Draft draft)
    {
        Draft = draft;
        IsFinished = draft.State == Draft.EState.Finished;
    }

    public bool AllConnected()
        => Draft.Profiles.All(p => ActiveProfiles.Any(a => a == p.Profile));

    public void Leave(Profile profile)
    {
        ActiveProfiles.Remove(profile);
    }
    
    public void Resume()
    {
        if (Draft.State != Draft.EState.Paused) return;

        Draft.State = Draft.EState.Ongoing;
    }

    public void Pause()
    {
        if (Draft.State != Draft.EState.Ongoing) return;

        Draft.State = Draft.EState.Paused;
    }

    public void AdvanceTime(int time)
    {
        Draft.Timer += time;
        if (Draft.Timer > Draft.PickTime)
            Advance();
    }

    public void Advance()
    {
        if (Draft.State == Draft.EState.Finished) return;

        Draft.Timer = 0;

        foreach (var draftPack in Draft.Packs.Where(p => p.Rotation == Draft.Rotation))
        {
            if (!draftPack.IsPicked)
                Pick(draftPack.Cards.FirstOrDefault(c => c.Profile == null));
            draftPack.Profile = Draft.GetDraftProfile(draftPack.Profile.NextProfile(Draft.Rotation));
        }

        Draft.Packs.ForEach(p => p.IsPicked = false);

        if (Draft.AllPicked()) Draft.Rotation++;
        if (Draft.AllPicked()) Draft.State = Draft.EState.Finished;
    }

    public void Pick(DraftPackCard card)
    {
        if (card == null || card.Pack.IsPicked || card.Profile != null) return;

        card.Profile = card.Pack.Profile.Profile;
        card.Pack.IsPicked = true;
    }

    public void AssignDecks()
    {
        foreach (var profile in Draft.Profiles)
        {
            profile.Deck = new Deck(Deck.EType.Draft, profile.Profile, "",
                Draft.PickedCards(profile.Profile).Select(c => c.Card));
        }
    }
    
}