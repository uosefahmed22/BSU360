using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness.Services
{
    public class Service : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string? CoverPictureUrl { get; set; }
    }

}
