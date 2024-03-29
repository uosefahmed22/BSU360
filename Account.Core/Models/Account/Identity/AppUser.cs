﻿using Account.Core.Models.Related;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Account.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
