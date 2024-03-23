using Account.Core.Models.ProjectBusiness;
using Account.Core.Models.ProjectBusiness.Contacts;
using Account.Core.Models.Related;
using Account.Core.Models.ServiceProvider.ContactsServiceProvider;
using System;
using System.Collections.Generic;
using Account.Core.Models.ServiceProvider;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ServiceProvider
{
    public class ServicesProviderdModel : BaseEntity
    {
        [Required(ErrorMessage = "Name in Arabic is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name in Arabic must be between 3 and 100 characters.")]
        public string NameAR { get; set; }

        [StringLength(100, ErrorMessage = "Name in English cannot exceed 100 characters.")]
        public string? NameENG { get; set; }

        [Required(ErrorMessage = "Description in Arabic is required.")]
        public string AboutAR { get; set; }
        public string? AboutENG { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Address { get; set; }
        public int WorkStartHour { get; set; }
        public int WorkEndHour { get; set; }
        public int WorkingDays { get; set; }
        public virtual ICollection<ServiceProviderAlbumUrl> ServiceProviderAlbumUrl { get; set; } = new List<ServiceProviderAlbumUrl>();
        public virtual ICollection<ServiceProviderHoliday> ServiceProviderHoliday { get; set; } = new List<ServiceProviderHoliday>();
        public virtual ICollection<ServiceProviderContacts> ServiceProviderContacts { get; set; } = new List<ServiceProviderContacts>();

        //public Guid ServiceProviderId { get; set; }
    }
}
