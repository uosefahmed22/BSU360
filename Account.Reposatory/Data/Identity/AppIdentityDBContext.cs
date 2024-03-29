﻿using Account.Core.Models.Account.Identity;
using Account.Reposatory.Data.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Account.Reposatory.Data.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedRoles(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "User", ConcurrencyStamp = "1", NormalizedName = "User" },
                new IdentityRole { Name = "BussinesOwner", ConcurrencyStamp = "2", NormalizedName = "BussinesOwner" },
                new IdentityRole { Name = "ServiceProvider", ConcurrencyStamp = "3", NormalizedName = "ServiceProvider" },
                new IdentityRole { Name = "Admin", ConcurrencyStamp = "4", NormalizedName = "Admin" }
            );
        }

    }

}
