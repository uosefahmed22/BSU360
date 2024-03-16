using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Models.Projectbusiness;
using Account.Core.Models.ProjectBusiness;
using Account.Core.Services.Business;
using Account.Reposatory.Data.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.Buisness
{
    public class BusnissRepository : IBusnissRepository
    {
        private readonly BusinessDbContext _context;

        public BusnissRepository(BusinessDbContext context)
        {
            _context = context;
        }


    }
}
