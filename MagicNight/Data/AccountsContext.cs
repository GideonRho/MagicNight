using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MagicNight.Data
{
    public class AccountsContext : IdentityDbContext
    {

        private IConfiguration Configuration { get; }
        
        public AccountsContext(DbContextOptions<AccountsContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite(
                $"Data Source={DatabaseName}");
        

        private string DatabaseName => Configuration["AccountsDatabase"];
        
    }
}