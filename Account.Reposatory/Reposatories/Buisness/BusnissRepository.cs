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

        public async Task<ApiResponse> AddBusnissAsync(BusinessModel businessModel)
        {
            _context.Businesses.Add(businessModel);
            await _context.SaveChangesAsync();

            return new ApiResponse(200, "Business added successfully.");
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BusinessModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BusinessModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateAsync(BusinessModel businessModel)
        {
            throw new NotImplementedException();
        }
    }
}
