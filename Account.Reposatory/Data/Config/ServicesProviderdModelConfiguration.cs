using Account.Core.Models.Projectbusiness;
using Account.Core.Models.ServiceProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Data.Config
{
    public class ServicesProviderdModelConfiguration : IEntityTypeConfiguration<ServicesProviderdModel>
    {
        public void Configure(EntityTypeBuilder<ServicesProviderdModel> builder)
        {
            builder.Property(b => b.Latitude)
                .HasColumnType("decimal(10, 8)");

            builder.Property(b => b.Longitude)
                .HasColumnType("decimal(11, 8)");

            builder.Property(b => b.Address)
                .IsRequired();

            builder.HasMany(b => b.ServiceProviderHoliday)
               .WithOne(h => h.ServicesProviderdModel)
               .HasForeignKey(h => h.ServicesProviderdModelId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.ServiceProviderAlbumUrl)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.ServiceProviderContacts)
                .WithOne(c => c.ServicesProviderdModel)
                .HasForeignKey(c => c.ServicesProviderdModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
