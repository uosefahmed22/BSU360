using Account.Core.Models.Projectbusiness;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }

}
