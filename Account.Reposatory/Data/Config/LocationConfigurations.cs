using Account.Core.Models.ProjectBusiness;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Data.Config
{
    public class LocationConfigurations : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(l => l.Latitude).HasColumnType("decimal").IsRequired();
            builder.Property(l => l.Longitude).HasColumnType("decimal").IsRequired();
        }
    }
}
