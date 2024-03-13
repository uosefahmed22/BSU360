using Account.Core.Models.Projectbusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Picture URL is required.")]
        public string PictureUrl { get; set; }

        // Ignoring this property during JSON serialization to avoid circular references
        [JsonIgnore] 
        public ICollection<BusinessModel>? Businesses { get; set; }
    }
}
