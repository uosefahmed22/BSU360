using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness
{
    public class Location : BaseEntity
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Business ID is required.")]
        [ForeignKey("Business")]
        public Guid BusinessId { get; set; }
    }
}
