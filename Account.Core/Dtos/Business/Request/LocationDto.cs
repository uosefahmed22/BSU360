using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Business.Request
{
    public class LocationDto
    {
        [Required(ErrorMessage = "Latitude is required.")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required.")]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}
