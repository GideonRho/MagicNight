using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace MagicNight.Models.Data
{
    public class UserWithRoles
    {
        
        public IdentityUser User { get; set; }
        public bool IsAdmin { get; set; }

        public UserWithRoles(IdentityUser user, bool isAdmin)
        {
            User = user;
            IsAdmin = isAdmin;
        }

        public string PrettyRoles => IsAdmin ? "Admin" : "";

    }
}