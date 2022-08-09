using System;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Data;
using MagicNight.Models.Database.Rolls;
using Microsoft.EntityFrameworkCore;

namespace MagicNight.Services
{
    public class RollService
    {
        
        private DatabaseContext Database { get; }
        private SetService SetService { get; }
        private MtgApiService MtgService { get; }
        private DeckService DeckService { get; }
        private CardService CardService { get; }
        private GenerateService GenerateService { get; }

        public RollService(DatabaseContext database, SetService setService, 
            MtgApiService mtgService, DeckService deckService, CardService cardService, GenerateService generateService)
        {
            Database = database;
            SetService = setService;
            MtgService = mtgService;
            DeckService = deckService;
            CardService = cardService;
            GenerateService = generateService;
        }

        public async Task CreateCommanderRoll(CommanderRoll data)
        {
            await Database.CommanderRolls.AddAsync(data);
            await Database.SaveChangesAsync();

        }

        public async Task Reroll(CommanderRoll roll, string user)
        {
            var colors = roll.GetColors(user);
            
            foreach (var entry in roll.ProfileEntries(user))
            {
                entry.Commander = await GenerateService.RandomCommander(entry.Commander.Colors);
                entry.Partner = await GenerateService.Partner(entry.Commander, colors);
            }
            
            Database.CommanderRolls.Update(roll);
            await Database.SaveChangesAsync();
        }
        
        public async Task CreateSetRoll(SetRoll data, int packs = 3, Action<int> progress = null)
        {
            var sets = await SetService.Query
                .Where(s => s.Settings.CanRoll)
                .ToListAsync();

            var random = new Random();
            foreach (var entry in data.Entries)
            {
                var roll = random.Next(sets.Count);
                entry.Set = sets[roll];
                entry.Deck = await MtgService.Boosters(entry.Profile, entry.Set, packs, progress);
                sets.RemoveAt(roll);
            }
            
            await Database.SetRolls.AddAsync(data);
            await Database.SaveChangesAsync();

            foreach (var entry in data.Entries)
            {
                await DeckService.ClearNullReferences(entry.Deck.Id);
                await DeckService.Save(entry.Deck);
            }
            
        }
        
        public async Task Delete(SetRoll set)
        {

            Database.SetRollEntries.RemoveRange(set.Entries);
            Database.SetRolls.Remove(set);
            await Database.SaveChangesAsync();

        }

        public async Task Delete(CommanderRoll data)
        {
            Database.CommanderRollEntries.RemoveRange(data.Entries);
            Database.CommanderRolls.Remove(data);
            await Database.SaveChangesAsync();
        }
        
        public IQueryable<SetRoll> AllSetRolls 
            => Database.SetRolls
                .Include(r => r.Entries)
                .ThenInclude(e => e.Profile)
                .Include(r => r.Entries)
                .ThenInclude(e => e.Set)
                .Include(r => r.Entries)
                .ThenInclude(e => e.Deck)
                .ThenInclude(d => d.Cards)
                .ThenInclude(c => c.Card);

        public IQueryable<CommanderRoll> AllCommanderRolls
            => Database.CommanderRolls
                .Include(r => r.Entries)
                .Include(r => r.Entries)
                .ThenInclude(e => e.Commander)
                .Include(r => r.Entries)
                .ThenInclude(e => e.Partner);

    }
}