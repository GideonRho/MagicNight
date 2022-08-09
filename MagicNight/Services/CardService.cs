using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Data;
using MagicNight.Misc;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Enums;
using MagicNight.Models.Filters;
using MagicNight.Models.Scryfall;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MagicNight.Services
{
    public class CardService
    {
        
        private DatabaseContext Database { get; }
        private CardsContext Cards { get; }
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }
        private DownloadService DownloadService { get; }

        public CardService(IConfiguration configuration, IWebHostEnvironment environment, DatabaseContext database, CardsContext cards, DownloadService downloadService)
        {
            Configuration = configuration;
            Environment = environment;
            Database = database;
            Cards = cards;
            DownloadService = downloadService;
        }

        public async Task<List<Card>> Take()
        {
            return await Database.Cards.Take(20).ToListAsync();
        }

        public async Task SetAllCommanders()
        {
            var cards = await Commanders()
                .Where(c => c.Commanders.Count == 0)
                .ToListAsync();

            await Database.Commanders.AddRangeAsync(cards.Select(c => new Commander(c)));
            await Database.SaveChangesAsync();

        }
        
        public void SetCommander(Card card, bool state)
        {
            bool hasChanged = false;

            if (!state && card.IsCommander())
            {
                Database.Commanders.RemoveRange(card.Commanders);
                hasChanged = true;
            }

            if (state && !card.IsCommander())
            {
                Database.Commanders.Add(new Commander(card.Name));
                hasChanged = true;
            }

            if (hasChanged)
                Database.SaveChanges();
        }
        
        public IQueryable<Card> Commanders(int page, int amount)
        {
            return Commanders()
                .OrderBy(c => c.ReleaseDate)
                .Skip(page * amount)
                .Take(amount)
                .Include(c => c.Commanders);
        }

        public int CommanderPages(int amount) => TotalCommanders() / amount;

        public int TotalCommanders()
        {
            return Commanders()
                .Count();
        }

        private IQueryable<Card> Commanders()
        {
            return Database.Cards
                .Where(c => c.Types.HasFlag(CardTypes.Legendary))
                .Where(c => c.Types.HasFlag(CardTypes.Creature) || c.Types.HasFlag(CardTypes.Planeswalker))
                .Where(c => !c.Types.HasFlag(CardTypes.Land));
        }

        public IQueryable<Card> Search(CardFilter filter, int amount, int page)
        {
            var colors = filter.ColorFilter.Flags();
            var types = filter.TypeFilter.Flags();
            return Database.Cards
                .Where(c => colors.HasFlag(c.Colors) && c.Colors != 0)
                .Where(c => c.Cost >= filter.MinCost && c.Cost <= filter.MaxCost)
                .Where(c => c.Types.HasFlag(types))
                .Where(c => c.Power >= filter.MinPower && c.Power <= filter.MaxPower || !c.Types.HasFlag(CardTypes.Creature))
                .Where(c => c.Toughness >= filter.MinToughness && c.Toughness <= filter.MaxToughness || !c.Types.HasFlag(CardTypes.Creature))
                .OrderBy(c => c.Cost)
                .Skip(page * amount)
                .Take(amount);
        }
        
        public async Task<string> Save(IEnumerable<Card> cards, IEnumerable<Card> sideboard = null)
        {
            string name = Guid.NewGuid().ToString();
            var path = DownloadService.TemporaryDeckPath(name);

            var lines = ExportLines(cards, sideboard);

            await File.WriteAllLinesAsync(path, lines);

            return name;
        }

        public static IEnumerable<string> ExportLines(IEnumerable<Card> cards, IEnumerable<Card> sideboard = null) =>
            sideboard != null
                ? cards.Select(c => c.ExportString())
                    .Concat(sideboard.Select(c => c.SideboardString()))
                : cards.Select(c => c.ExportString());

        public async Task ReloadCards()
        {
            Database.Cards.RemoveRange(Database.Cards);
            Database.CardMinorTypes.RemoveRange(Database.CardMinorTypes);
            Database.CardSynergies.RemoveRange(Database.CardSynergies);
            Database.CardKeyword.RemoveRange(Database.CardKeyword);

            await Database.Cards.AddRangeAsync(Cards.Cards);
            await Database.CardMinorTypes.AddRangeAsync(Cards.CardMinorTypes);
            await Database.CardSynergies.AddRangeAsync(Cards.CardSynergies);
            await Database.CardKeyword.AddRangeAsync(Cards.CardKeyword);

            await Database.SaveChangesAsync();

        }
        
        public async Task ImportCards()
        {
            Cards.Cards.RemoveRange(Cards.Cards);
            Cards.CardMinorTypes.RemoveRange(Cards.CardMinorTypes);
            Cards.CardSynergies.RemoveRange(Cards.CardSynergies);
            Cards.CardKeyword.RemoveRange(Cards.CardKeyword);
            var cards = LoadCards()
                .Distinct(new ScryfallCardComparer())
                .Where(Validate)
                .Select(c => new Card(c)).ToList();
            await Cards.Cards.AddRangeAsync( cards);
            BuildSynergies();
            await Cards.SaveChangesAsync();
            await BuildPartners();
        }

        public async Task BuildPartners()
        {
            var cards = await Database.Cards.ToListAsync();
            cards.ForEach(c => c.BuildPartner(cards));
            await Database.SaveChangesAsync();
            
        }

        public IEnumerable<ScryfallCard> LoadCards()
        {
            using StreamReader r = new StreamReader(CardsFile);
            using JsonReader reader = new JsonTextReader(r);
            JsonSerializer serializer = new JsonSerializer();
            var data = serializer.Deserialize<List<ScryfallCard>>(reader);
            return data?
                .Where(c => c.Lang == "en")
                .Where(c => c.Legalities != null && c.Legalities.Values.Any(s => s == "legal"));
        }

        private bool Validate(ScryfallCard card)
        {
            if (card.Type_Line == null) return false;
            return true;
        }
        
        private void BuildSynergies()
        {
            var types = DistinctMinorTypes().ToList();
            var cards = Database.Cards
                .Include(c => c.MinorTypes)
                .ToList();
            cards.ForEach(c => c.UpdateSynergies(types));
        }

        private IEnumerable<string> DistinctMinorTypes()
        {
            return Database.CardMinorTypes
                .GroupBy(c => c.Type)
                .Select(t => t.Key);
        }
        
        public string DataDirectory => Configuration["DataDirectory"];
        public string CardsFile => $"{DataDirectory}cards.json";

    }
}