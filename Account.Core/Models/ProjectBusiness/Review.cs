using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness
{
    public class Review : BaseEntity
    {
        [Range(0, 5, ErrorMessage = "Rate must be between 0 and 5.")]
        public int Rate { get; set; }

        public string? Comment { get; set; }

        [Required(ErrorMessage = "Business ID is required.")]
        [ForeignKey("Business")]
        public Guid BusinessId { get; set; }

        public Guid UserId { get; set; }

        public DateTime? LastModified { get; set; } = DateTime.Now;
    }
}
