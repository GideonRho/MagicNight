using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MagicNight.Models.Data.Drafts;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Database.Decks;
using MagicNight.Models.Database.Decks.Values;
using MagicNight.Models.Database.Profiles;
using MagicNight.Models.Database.Sets;
using MagicNight.Models.Enums;
using MtgApiManager.Lib.Service;

namespace MagicNight.Services
{
    public class MtgApiService
    {

        private IMtgServiceProvider ServiceProvider { get; }
        private ISetService SetService { get; }
        private ICardService CardService { get; }
        
        public MtgApiService()
        {
            ServiceProvider = new MtgServiceProvider();
            SetService = ServiceProvider.GetSetService();
            CardService = ServiceProvider.GetCardService();
        }

        public async Task<IEnumerable<Set>> AllSet()
        {
            var result = await SetService.AllAsync();
            return result.Value.Select(s => new Set(s));
        }

        public Pack OpenPack(PackType type) => new Pack(Open(type).ToList());
        
        public IEnumerable<Card> Open(PackType pack)
        {
            var random = new Random();
            
            var common = pack.Set.Cards
                .Where(c => c.Rarity == Rarity.Common)
                .Select(c => (c, random.Next()))
                .OrderBy(c => c.Item2)
                .Select(c => c.c.Card)
                .Take(10);
            
            var uncommon = pack.Set.Cards
                .Where(c => c.Rarity == Rarity.Uncommon)
                .Select(c => (c, random.Next()))
                .OrderBy(c => c.Item2)
                .Select(c => c.c.Card)
                .Take(3);
            
            var rare = pack.Set.Cards
                .Where(c => c.Rarity is Rarity.Rare or Rarity.Mythic)
                .Select(c => (c, random.Next()))
                .OrderBy(c => c.Item2)
                .Select(c => c.c.Card)
                .Take(1);

            return common.Concat(uncommon).Concat(rare);
        }

        public async Task<IEnumerable<string>> Booster(Set set)
        {
            var result = await SetService.GenerateBoosterAsync(set.Code);
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Exception);
                return Enumerable.Empty<string>();
            }
            return result.Value.Select(c => c.Name);
        }

        public async Task<Deck> Boosters(Profile owner, Set set, int amount, Action<int> progress = null)
        {
            var deck = new Deck(Deck.EType.Roll, owner, set.Code);

            for (int i = 0; i < amount; i++)
            {
                var booster = await Booster(set);
                deck.Cards.AddRange(booster.Select(c => new DeckCard(deck, c)));
                progress?.Invoke(i);
            }
            
            return deck;
        }

    }
}