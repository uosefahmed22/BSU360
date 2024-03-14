using Account.Core.Models.ProjectBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Data.Config
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(l => l.Latitude)
                .HasColumnType("decimal(10, 7)");
            builder.Property(l => l.Longitude)
                .HasColumnType("decimal(10, 7)");
        }
    }

}
