﻿using Account.Core.Models.Projectbusiness;
using Account.Core.Models.ProjectBusiness;
using Account.Core.Models.ProjectBusiness.Contacts;
using Account.Core.Models.ProjectBusiness.Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Data.Business
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<BusinessModel> Businesses { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<AlbumUrl> AlbumUrls { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }

}
