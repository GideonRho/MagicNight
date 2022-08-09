using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Data;
using MagicNight.Models.Database.Decks;
using MagicNight.Models.Database.Decks.Values;
using MagicNight.Models.Database.Profiles;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace MagicNight.Services
{
    public class DeckService
    {
        
        private DatabaseContext Database { get; }
        private ImportService ImportService { get; }
        private CardService CardService { get; }
        private DownloadService DownloadService { get; }
        
        public DeckService(DatabaseContext database, ImportService importService, CardService cardService, DownloadService downloadService)
        {
            Database = database;
            ImportService = importService;
            CardService = cardService;
            DownloadService = downloadService;
        }

        public IQueryable<Deck> ForProfile(Profile profile)
        {
            return Database.Decks
                .Where(d => d.Owner == profile);
        }

        public async Task<Deck> Upload(Profile profile, IBrowserFile file)
        {
            var deck = new Deck();
            deck.Owner = profile;
            deck.Name = file.Name;

            var content = (await new StreamReader(file.OpenReadStream())
                .ReadToEndAsync())
                .Split('\n');

            deck.Cards= (await ImportService.FromStringList(content))
                .Where(c => c != null)
                .Select(c => new DeckCard(deck, c))
                .ToList();
            
            await Create(deck);
            
            return deck;
        }

        public async Task ClearNullReferences(int deckId)
        {
            var deck = await Database.Decks
                .Include(d => d.Cards)
                .ThenInclude(c => c.Card)
                .FirstAsync(d => d.Id == deckId);
            var toRemove = deck.Cards
                .Where(c => c.Card == null)
                .ToList();
            deck.Cards.RemoveAll(c => c.Card == null);
            Database.DeckCards.RemoveRange(toRemove);
            Database.Decks.Update(deck);
            await Database.SaveChangesAsync();
        }
        
        public async Task Save(Deck deck)
        {

            var lines = CardService.ExportLines(deck.Cards.Select(c =>  c.Card));
            await File.WriteAllLinesAsync(DownloadService.DeckPath(deck.Id), lines);

        }
        
        public Task<Deck> Get(int id)
        {
            return Database.Decks
                .Include(d => d.Cards)
                .ThenInclude(c => c.Card)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        
        public async Task Create(Deck deck)
        {
            await Database.Decks.AddAsync(deck);
            await Database.SaveChangesAsync();
        }

        public async Task Update(Deck deck)
        {
            Database.Decks.Update(deck);
            await Database.SaveChangesAsync();
        }

        public async Task Delete(Deck deck)
        {
            Database.Decks.Remove(deck);
            await Database.SaveChangesAsync();
        }

    }
}