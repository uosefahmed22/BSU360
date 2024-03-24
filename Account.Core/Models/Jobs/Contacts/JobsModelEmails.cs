using Account.Core.Models.Properties.Contacts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Jobs.Contacts
{
    public class JobsModelEmails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }
        public Guid JobsModelContactsId { get; set; }
        public JobsModelContacts JobsModelContacts { get; set; }
    }
}
