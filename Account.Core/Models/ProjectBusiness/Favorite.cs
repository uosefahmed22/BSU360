using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness
{
    public class Favorite
    {
        public Guid UserId { get; set; }
    }
    public class FavoriteBusniss : Favorite
    {
        public Guid BusnissId { get; set; }
    }
}
