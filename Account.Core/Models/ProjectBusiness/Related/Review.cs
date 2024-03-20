using Account.Core.Models.Projectbusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness.Related
{
    public class Review : BaseEntity
    {
        public string Text { get; set; }

        // Navigation properties
        public Guid BusinessId { get; set; }
        public BusinessModel Business { get; set; }
    }
}
