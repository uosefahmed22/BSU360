using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ServiceProvider
{
    public class ServiceProviderHoliday
    {
        public int Id { get; set; }
        public DateTime HolidayDate { get; set; }
        public Guid ServicesProviderdModelId { get; set; }
        public ServicesProviderdModel ServicesProviderdModel { get; set; }
    }
}
