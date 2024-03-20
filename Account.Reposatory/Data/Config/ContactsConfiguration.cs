using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Data.Config
{
    using Account.Core.Models.ProjectBusiness.Contacts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContactsConfiguration : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> builder)
        {
            builder.HasMany(c => c.Emails)
                   .WithOne(e => e.Contact) 
                   .HasForeignKey(e => e.ContactId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.PhoneNumbers)
                   .WithOne(p => p.Contact)  
                   .HasForeignKey(p => p.ContactId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.URlSites)
                   .WithOne(u => u.Contact)
                   .HasForeignKey(u => u.ContactId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
