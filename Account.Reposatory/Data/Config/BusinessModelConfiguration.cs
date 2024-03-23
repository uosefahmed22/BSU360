using Account.Core.Models.Projectbusiness;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.ProjectBusiness.Contacts;
using System.Reflection.Emit;

namespace Account.Reposatory.Data.Config
{
    public class BusinessModelConfiguration : IEntityTypeConfiguration<BusinessModel>
    {
        public void Configure(EntityTypeBuilder<BusinessModel> builder)
        {
            builder.Property(b => b.Latitude)
                .HasColumnType("decimal(10, 8)");

            builder.Property(b => b.Longitude)
                .HasColumnType("decimal(11, 8)");

            builder.Property(b => b.Address)
                .IsRequired();

            builder.HasMany(b => b.Holidays)
               .WithOne(h => h.Business)
               .HasForeignKey(h => h.BusinessId) 
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.AlbumUrls)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.Contacts)
                .WithOne(c => c.BusinessModel)
                .HasForeignKey(c => c.BusinessModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }

}
