using Account.Core.Models.Projectbusiness;
using Account.Core.Models.ProjectBusiness;
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
    public class BusnissDbContext : DbContext
    {
        public BusnissDbContext(DbContextOptions<BusnissDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<WorkTime>(entity =>
            //{
            //    entity.Property(e => e.End)
            //      .IsRequired()  
            //      .HasConversion(
            //          v => v.ToTimeSpan(),
            //          v => TimeOnly.FromTimeSpan(v)
            //      );
            //    entity.Property(e => e.Start)
            //     .IsRequired()  
            //     .HasConversion(
            //         v => v.ToTimeSpan(),
            //         v => TimeOnly.FromTimeSpan(v)
            //     );
            //});

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<BusinessModel> Busnisses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WorkTime> WorkTime { get; set; }
        public DbSet<FavoriteBusniss> FavoriteBusnisses { get; set; }
    }
}
