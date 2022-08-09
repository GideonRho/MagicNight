using System;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Data;
using MagicNight.Misc;
using MagicNight.Models.Database.Sets;
using Microsoft.EntityFrameworkCore;

namespace MagicNight.Services
{
    public class SetService
    {
        
        private DatabaseContext Database { get; }
        private MtgApiService ApiService { get; }
        private CardService CardService { get; }

        public SetService(DatabaseContext database, MtgApiService apiService, CardService cardService)
        {
            Database = database;
            ApiService = apiService;
            CardService = cardService;
        }

        public async Task ImportSets()
        {
            var settings = await Database.SetSettings.ToListAsync();
            
            Database.Sets.RemoveRange(Database.Sets);
            var sets = (await ApiService.AllSet()).ToList();

            foreach (var set in sets)
            {
                var s = settings.FirstOrDefault(s => s.Code == set.Code);
                if (s != null)
                {
                    set.Settings = s;
                    continue;
                }
                set.Settings = new SetSettings(set);
            }
            
            await Database.Sets.AddRangeAsync(sets);
            await Database.SaveChangesAsync();
        }

        public async Task LinkCards()
        {
            var setStore = new FastSetStore(Database.Sets);
            var cardStore = new FastCardStore(Database.Cards);

            var cards = CardService.LoadCards()
                .Where(c => setStore.Contains(c.Set))
                .Where(c => cardStore.Contains(c.Name))
                .Select(c => new SetCard(c))
                .ToList();
            
            await Database.SetCards.AddRangeAsync(cards);
            await Database.SaveChangesAsync();
        }
        
        public async Task SetCanRoll(Set set, bool state)
        {
            set.Settings.CanRoll = state;
            Database.Sets.Update(set);
            await Database.SaveChangesAsync();
        }

        public IQueryable<Set> Query => Database.Sets
            .Include(s => s.Settings)
            .Include(s => s.Cards)
            .ThenInclude(c => c.Card);

    }
}