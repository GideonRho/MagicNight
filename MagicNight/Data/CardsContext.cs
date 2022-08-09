using MagicNight.Models.Database.Cards;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MagicNight.Data
{
    public class CardsContext : DbContext
    {
        
        private IConfiguration Configuration { get; }
        
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardMinorType> CardMinorTypes { get; set; }
        public DbSet<CardSynergy> CardSynergies { get; set; }
        public DbSet<CardKeyword> CardKeyword { get; set; }
        
        public CardsContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite(
                $"Data Source={DatabaseName}");
        
        private string DatabaseName => Configuration["CardsDatabase"];
    }
}