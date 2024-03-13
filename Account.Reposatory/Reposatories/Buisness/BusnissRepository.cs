using Account.Core.Errors;
using Account.Core.Models.Response;
using Account.Core.Services.Business;
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
        //public async Task<IReadOnlyList<BusinessResponse>> GetAllBusinessesWithCategoryIdAsync(Guid Id)
        //{
        //    // Check if the category with the given ID exists
        //    if (!await _context.Categories.AnyAsync(c => c.Id == Id))
        //        throw new ItemNotFoundException("Category Was Not Found");

        //    // Retrieve businesses with the specified category ID
        //    var businesses = await _context.Businesses.AsNoTracking()
        //        .Where(b => b.Id == Id)
        //        // Map each business entity to a BusinessResponse using a mapping function
        //        .Select(business => business.MapToBusinessResponse(_reviewService, _fileService))
        //        .ToListAsync();

        //    // Return the list of mapped BusinessResponse objects
        //    return businesses;
        //}
        public Task<IReadOnlyList<BusinessResponse>> GetAllBusinessesWithCategoryIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
