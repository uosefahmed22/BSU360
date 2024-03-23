using Account.Core.Models.Projectbusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness
{
    public class Holiday
    {
        public int Id { get; set; }
        public DateTime HolidayDate { get; set; }
        public Guid BusinessId { get; set; }
        public BusinessModel Business { get; set; }
    }
}
