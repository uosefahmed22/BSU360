using Account.Core.Models.Projectbusiness;
using Account.Core.Models.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Data.Config
{
    public class PropertiesModelConfiguration: IEntityTypeConfiguration<PropertiesModel>
    {
        public void Configure(EntityTypeBuilder<PropertiesModel> builder)
        {
            builder.Property(b => b.Salary)
                .HasColumnType("decimal(10, 8)");

            builder.HasMany(b => b.PropertiesAlbumUrl)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.ContactsOfProperties)
                .WithOne(c => c.PropertiesModel)
                .HasForeignKey(c => c.PropertiesModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
