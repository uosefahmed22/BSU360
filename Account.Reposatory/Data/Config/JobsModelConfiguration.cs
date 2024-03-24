using Account.Core.Models.Jobs;
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
    public class JobsModelConfiguration : IEntityTypeConfiguration<JobsModel>
    {
        public void Configure(EntityTypeBuilder<JobsModel> builder)
        {
            builder.Property(b => b.Salary)
                .HasColumnType("decimal(10, 8)");

           

            builder.HasMany(b => b.JobsModelContacts)
                .WithOne(c => c.JobsModel)
                .HasForeignKey(c => c.JobsModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
