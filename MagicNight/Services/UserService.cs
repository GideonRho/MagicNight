using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Models.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MagicNight.Services
{
    public class UserService
    {

        public static string RoleAdmin => "admin";
        
        private UserManager<IdentityUser> UserManager { get; }
        private RoleManager<IdentityRole> RoleManager { get; }
        private AuthenticationStateProvider AuthenticationState { get; }

        public UserService(UserManager<IdentityUser> userManager, AuthenticationStateProvider authenticationState, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            AuthenticationState = authenticationState;
            RoleManager = roleManager;
        }

        public IQueryable<IdentityUser> Users => UserManager.Users;

        public async Task<List<UserWithRoles>> UsersWithRoles()
        {
            var users = await Users.ToListAsync();
            var result = users.Select(u =>
                User(u.UserName).Result)
                .ToList();
            return result;
        }

        public async Task<UserWithRoles> User(string name)
        {
            var user = Users.FirstOrDefault(u => u.UserName == name);
            if (user == null) return null;
            var isAdmin = await UserManager.IsInRoleAsync(user, RoleAdmin);
            return new UserWithRoles(user, isAdmin);
        }

        public async Task Create(string name, string password)
        {
            var user = new IdentityUser(name);
            await UserManager.CreateAsync(user, password);
        }

        public async Task Delete(IdentityUser user)
        {
            if (user == null) return;
            await UserManager.DeleteAsync(user);

        }

        public async Task GiveAdmin(IdentityUser user)
        {
            await UserManager.AddToRoleAsync(user, RoleAdmin);
        }

        public async Task RevokeAdmin(IdentityUser user)
        {
            await UserManager.RemoveFromRoleAsync(user, RoleAdmin);
        }
        
        public async Task GiveAdminToCurrent()
        {
            if (!RoleManager.Roles.Any(r => r.Name == RoleAdmin))
                await RoleManager.CreateAsync(new IdentityRole(RoleAdmin));
            var state = await AuthenticationState.GetAuthenticationStateAsync();
            var user = await UserManager.GetUserAsync(state.User);
            await UserManager.AddToRoleAsync(user, RoleAdmin);
        }

    }
}