using System.Linq;
using System.Threading.Tasks;
using MagicNight.Data;
using MagicNight.Models.Database.Profiles;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;

namespace MagicNight.Services
{
    public class ProfileService
    {
        
        private DatabaseContext Database { get; }
        private IConfiguration Configuration { get; }
        private AuthenticationStateProvider AuthenticationStateProvider { get; }

        public ProfileService(DatabaseContext database, IConfiguration configuration, AuthenticationStateProvider authenticationStateProvider)
        {
            Database = database;
            Configuration = configuration;
            AuthenticationStateProvider = authenticationStateProvider;
        }

        public async Task<Profile> Current()
        {
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = state.User;
            if (user.Identity == null) return null;
            var profileName = user.Identity.Name;
            if (profileName == null) return null;
            
            var profile = Database.Profiles
                .FirstOrDefault(p => p.Name == profileName) 
                          ?? await AddProfile(profileName);

            return profile;
        }

        private async Task<Profile> AddProfile(string name)
        {
            var profile = new Profile(name);
            await Database.Profiles.AddAsync(profile);
            await Database.SaveChangesAsync();
            return profile;
        }
        
        public IQueryable<Profile> All()
            => Database.Profiles;

        public IQueryable<Profile> Active => All().Where(p => !p.IsDisabled);

        public async Task<Profile> Add(Profile profile)
        {

            await Database.Profiles.AddAsync(profile);
            await Database.SaveChangesAsync();
            
            return profile;
        }

        public async Task Disable(Profile profile)
        {
            profile.IsDisabled = true;
            Database.Profiles.Update(profile);
            await Database.SaveChangesAsync();
        }
        
        public async Task Enable(Profile profile)
        {
            profile.IsDisabled = false;
            Database.Profiles.Update(profile);
            await Database.SaveChangesAsync();
        }

        public async Task Delete(Profile profile)
        {
            Database.Profiles.Remove(profile);
            await Database.SaveChangesAsync();
        }
        
    }
}