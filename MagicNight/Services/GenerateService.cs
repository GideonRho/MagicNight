using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Data;
using MagicNight.Misc;
using MagicNight.Models.Data;
using MagicNight.Models.Data.Generating;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Enums;
using MagicNight.Models.Filters;
using MagicNight.Models.Sorting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MagicNight.Services
{
    public class GenerateService
    {
        
        private DatabaseContext Database { get; }
        private IConfiguration Configuration { get; }

        public GenerateService(DatabaseContext database, IConfiguration configuration)
        {
            Database = database;
            Configuration = configuration;
        }

        public IEnumerable<Card> ForBuilder(DeckGeneratorData builder) => 
            builder
                .Prepare()
                .Build()
                .SelectMany(ForCardSlot)
                .Concat(ManaBase(builder.ManaBase()));

        private IEnumerable<Card> ForCardSlot(CardSlot slot)
        {
            var random = new Random();
            return Database.Cards
                .Filter(slot)
                .Include(c => c.MinorTypes)
                .Include(c => c.Synergies)
                .ToList()
                .Select(c => new ValuedCard(c,slot, random))
                .OrderByDescending(c => c.Value)
                .Take(slot.Amount)
                .Select(c => c.Card);
        }
        
        public async Task<Card> RandomCommander()
        {
            var commanders = await RandomCommanderList() 
                .ToListAsync();
            var random = new Random();
            return commanders[random.Next(commanders.Count)];
        }
        
        public async Task<Card> RandomCommander(Colors colors)
        {
            var commanders = await RandomCommanderList()
                .Where(c => c.Colors == colors)
                .ToListAsync();
            var random = new Random();
            return commanders[random.Next(commanders.Count)];
        }

        public async Task<Card> Partner(Card card, Colors colors)
        {
            if (card.Partner != null) return card.Partner;
            if (card.Keywords.All(k => k.Name != KeyWord.Partner.DbString())) return null;
            return await RandomPartner(card, colors);
        }
        
        public async Task<Card> RandomPartner(Card card, Colors colors)
        {
            var partners = await GenericPartnerList()
                .Where(c => c.Name != card.Name)
                .Where(c => colors.HasFlag(c.Colors))
                .ToListAsync();
            var random = new Random();
            return partners[random.Next(partners.Count)];
        }

        public async Task<Card> RandomCommanderWild(ColorSet set)
        {
            var commanders = await RandomCommanderList()
                .Where(c => c.Colors == 0 || c.Colors == set.Primary || c.Colors == set.SecondaryCombination || c.Colors.HasFlag(set.Combination))
                .ToListAsync();
            var random = new Random();
            return commanders[random.Next(commanders.Count)];
        }

        private IQueryable<Card> RandomCommanderList()
        {
            return Database.Cards
                .Where(c => c.Types.HasFlag(CardTypes.Legendary))
                .Where(c => c.Types.HasFlag(CardTypes.Creature) || c.Types.HasFlag(CardTypes.Planeswalker))
                .Include(c => c.Commanders)
                .Where(c => c.Commanders.Count > 0)
                .Include(c => c.MinorTypes)
                .Include(c => c.Synergies)
                .Include(c => c.Keywords)
                .Include(c => c.Partner);
        }

        private IQueryable<Card> GenericPartnerList()
        {
            return RandomCommanderList()
                .Where(c => c.Keywords.Any(k => k.Name == KeyWord.Partner.DbString()))
                .Where(c => c.Keywords.All(k => k.Name != KeyWord.PartnerWith.DbString()));
        }

        public IEnumerable<Card> Edh(EdhGenFilter filter)
        {

            var creatures = Valued(filter, CardTypes.Creature, filter.Creatures).ToList();
            var artifacts = Valued(filter, CardTypes.Artifact, filter.Artifacts).ToList();
            var spells = Valued(filter, CardTypes.Sorcery | CardTypes.Instant, filter.Spells).ToList();

            var mana = ManaBase(filter.ManaFilter()).ToList();

            foreach (var card in creatures)
                yield return card;
            foreach (var card in artifacts)
                yield return card;
            foreach (var card in spells)
                yield return card;
            foreach (var card in mana)
                yield return card;
            
        }
        
        public IEnumerable<Card> ManaBase(ManaBaseFilter filter)
        {
            foreach (var card in Lands(filter))
                yield return card;
            foreach (var card in Artifacts(filter))
                yield return card;
        }

        private IEnumerable<Card> Lands(ManaBaseFilter filter)
        {
            List<Colors> combinations = filter.ColorFilter.ColorCombinations().ToList();

            List<Func<int, IEnumerable<Card>>> funcs = new();
            foreach (var combination in combinations)
                funcs.Add(i => Lands(combination, i));

            var nonBasics = filter.Lands - filter.BasicLands;
            foreach (var card in GenerateCards(funcs, i => FillBasicLands(filter.ColorFilter.Flags(), i), nonBasics))
                yield return card;

            foreach (var card in FillBasicLands(filter.ColorFilter.Flags(), filter.BasicLands))
                yield return card;
        }

        private IEnumerable<Card> Artifacts(ManaBaseFilter filter)
        {
            List<Colors> combinations = filter.ColorFilter.ColorCombinations().ToList();

            if (filter.Artifacts2 > 0)
                foreach (var artifact in Artifacts(filter.ColorFilter.Flags(), combinations, 2, filter.Artifacts2))
                    yield return artifact;
            
            if (filter.Artifacts3 > 0)
                foreach (var artifact in Artifacts(filter.ColorFilter.Flags(), combinations, 3, filter.Artifacts3))
                    yield return artifact;

        }
        
        private IEnumerable<Card> Artifacts(Colors allColors, IEnumerable<Colors> combinations, int cmc, int amount)
        {
            List<Func<int, IEnumerable<Card>>> funcs = new();
            foreach (var combination in combinations)
                funcs.Add(i => Artifacts(combination, cmc, i));
            
            return GenerateCards(funcs, i => FillerArtifacts(allColors, cmc, i), amount);
        }
        
        private IEnumerable<Card> GenerateCards(
            IReadOnlyCollection<Func<int, IEnumerable<Card>>> functions,
            Func<int, IEnumerable<Card>> filler,
            int amount)
        {
            int rest = amount;

            if (functions.Count > 0)
            {
                int split = rest / functions.Count;

                foreach (var func in functions)
                {
                    var cards = func(split).ToList();
                    rest -= cards.Count;
                    foreach (var card in cards)
                        yield return card;
                }
            }

            if (rest <= 0) yield break;
            
            foreach (var card in filler(rest))
                yield return card;

        }

        private IEnumerable<Card> Valued(EdhGenFilter filter, CardTypes types, int amount)
        {
            var random = new Random();
            return Database.Cards
                .Where(c => types.HasFlag(c.Types))
                .Where(c => filter.Commander.Colors.HasFlag(c.Colors))
                .Include(c => c.MinorTypes)
                .Include(c => c.Synergies)
                .ToList()
                .Select(c => new ValuedCard(c, filter, random))
                .OrderByDescending(c => c.Value)
                .Take(amount)
                .Select(c => c.Card);
        }
        
        private IEnumerable<Card> Artifacts(Colors colors, int cmc, int amount)
        {
            return Database.Cards
                .Where(c => c.Types == CardTypes.Artifact)
                .Where(c => c.ProducedMana == colors)
                .Where(c => c.Cost == cmc)
                .OrderBy(c => c.Rank)
                .Take(amount);
        }
        
        private IEnumerable<Card> FillerArtifacts(Colors colors, int cmc, int amount)
        {
            return Database.Cards
                .Where(c => c.Types == CardTypes.Artifact)
                .Where(c => (c.ProducedMana & colors) > 0 )
                .Where(c => c.Cost == cmc)
                .OrderBy(c => c.Rank)
                .Take(amount);
        }

        private IEnumerable<Card> FillBasicLands(Colors colors, int amount)
        {
            int rest = amount;
            var combinations = colors.Combinations(1).ToList();
            int split = rest / combinations.Count();

            for (int i = 0; i < combinations.Count; i++)
            {
                int count = i-1 == combinations.Count ? rest : split;
                foreach (var basicLand in BasicLands(combinations[i], count))
                    yield return basicLand;
                rest -= split;
            }
        }
        
        private IEnumerable<Card> BasicLands(Colors color, int amount)
        {
            var card = Database.Cards
                .Where(c => c.Types == (CardTypes.Land | CardTypes.Basic))
                .FirstOrDefault(c => c.ProducedMana == color);
            if (card == null) yield break;
            for (int i = 0; i < amount; i++)
                yield return card;
        } 
        
        private IEnumerable<Card> Lands(Colors colors, int amount)
        {
            return Database.Cards
                .Where(c => c.Types == CardTypes.Land)
                .Where(c => c.ProducedMana == colors)
                .OrderBy(c => c.Rank)
                .Take(amount);
        }

    }
}