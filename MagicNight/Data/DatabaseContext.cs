using MagicNight.Models.Database.Cards;
using MagicNight.Models.Database.Decks;
using MagicNight.Models.Database.Decks.Values;
using MagicNight.Models.Database.Drafts;
using MagicNight.Models.Database.Drafts.Values;
using MagicNight.Models.Database.Profiles;
using MagicNight.Models.Database.Rolls;
using MagicNight.Models.Database.Rolls.Values;
using MagicNight.Models.Database.Sets;
using MagicNight.Models.Database.Tournaments;
using MagicNight.Models.Database.Tournaments.Values;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MagicNight.Data
{
    public class DatabaseContext : DbContext
    {
        
        private IConfiguration Configuration { get; }
        
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<DeckCard> DeckCards { get; set; }
        public DbSet<Commander> Commanders { get; set; }
        
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupEntry> GroupEntries { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<SetRoll> SetRolls { get; set; }
        public DbSet<SetRollEntry> SetRollEntries { get; set; }
        public DbSet<CommanderRollLobby> CommanderRollLobbies { get; set; }
        public DbSet<CommanderRollLobbyEntry> CommanderRollLobbyEntries { get; set; }
        public DbSet<CommanderRoll> CommanderRolls { get; set; }
        public DbSet<CommanderRollEntry> CommanderRollEntries { get; set; }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardMinorType> CardMinorTypes { get; set; }
        public DbSet<CardSynergy> CardSynergies { get; set; }
        public DbSet<CardKeyword> CardKeyword { get; set; }
        
        public DbSet<Set> Sets { get; set; }
        public DbSet<SetSettings> SetSettings { get; set; }
        public DbSet<SetCard> SetCards { get; set; }

        public DbSet<Draft> Drafts { get; set; }
        public DbSet<DraftPack> DraftPacks { get; set; }
        public DbSet<DraftPackCard> DraftPackCards { get; set; }
        public DbSet<DraftProfile> DraftProfiles { get; set; }

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite(
                $"Data Source={DatabaseName}");
        

        private string DatabaseName => Configuration["Database"];
        
    }
}