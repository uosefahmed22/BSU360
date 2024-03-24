using Account.Core.Models.Account.Identity;
using Account.Core.Models.Projectbusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Related
{
    public class Favorite : BaseEntity
    {
        public AppUser User { get; set; }
        public Guid BusinessId { get; set; }
        public BusinessModel Business { get; set; }
    }
}
