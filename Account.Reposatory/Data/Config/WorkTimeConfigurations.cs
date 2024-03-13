using Account.Core.Models.ProjectBusiness;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.Projectbusiness;

namespace Account.Reposatory.Data.Config
{
    public class WorkTimeConfigurations : IEntityTypeConfiguration<WorkTime>
    {
        public void Configure(EntityTypeBuilder<WorkTime> builder)
        {
            builder.HasOne<BusinessModel>()
                .WithMany(b => b.WorkTimes)
                .HasForeignKey(wt => wt.BusinessId)
                .IsRequired(false);
        }
    }
}
