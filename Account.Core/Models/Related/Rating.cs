using Account.Core.Models.Projectbusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Related
{
    public class Rating : BaseEntity
    {
        [Range(1, 5, ErrorMessage = "Rating value must be between 1 and 5.")]
        public int Value { get; set; }

        public Guid BusinessId { get; set; }
        public BusinessModel Business { get; set; }
    }

}
