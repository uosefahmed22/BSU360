using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness.Services
{
    public class ServiceProvider : BaseEntity
    {
        public Guid ServiceId { get; set; }
        public virtual Service? Service { get; set; }
    }

}
