using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.ServiceProvider
{
    public class ServicesProviderDto
    {
        public Guid Id { get; set; }
        public string NameAR { get; set; }
        public string NameENG { get; set; }
        public string AboutAR { get; set; }
        public string AboutENG { get; set; }
        public string ProfilePictureUrl { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Address { get; set; }
        public int WorkStartHour { get; set; }
        public int WorkEndHour { get; set; }
        public int WorkingDays { get; set; }
        public List<string> AlbumUrls { get; set; }
        public List<DateTime> Holidays { get; set; }
        public ServicesProviderContactsDto ServicesProviderContactsDto { get; set; }
        // Commented out until ServiceProvider is created
        // public Guid ServiceProviderId { get; set; }
    }
}
