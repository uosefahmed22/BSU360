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
    public class FavoriteBusnissConfigurations : IEntityTypeConfiguration<FavoriteBusniss>
    {
        public void Configure(EntityTypeBuilder<FavoriteBusniss> builder)
        {
            //Composie key
            builder.HasKey(fav => new { fav.UserId, fav.BusnissId });

        }
    }
}
