using Account.Apis.Errors;
using Account.Core.Models.Projectbusiness;
using Account.Core.Models.ProjectBusiness;
using Account.Core.Models.ProjectBusiness.Related;
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
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly BusinessDbContext _context;

        public FavoriteRepository(BusinessDbContext context)
        {
           _context = context;
        }
        public async Task<ApiResponse> AddFavoriteAsync(Guid userId, Guid businessId)
        {
            var existingFavorite = await _context.Favorites.FirstOrDefaultAsync(f => f.Id == userId && f.BusinessId == businessId);

            if (existingFavorite != null)
            {
                return new ApiResponse(400, "Favorite already exists");
            }

            var favorite = new Favorite
            {
               Id = userId,
                BusinessId = businessId
            };

            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();

            return new ApiResponse(200, "Favorite added successfully");
        }
        public async Task<ApiResponse> RemoveFavoriteAsync(Guid userId, Guid businessId)
        {
            var favorite = await _context.Favorites
                .FirstOrDefaultAsync(f => f.Id == userId && f.BusinessId == businessId);

            if (favorite == null)
            {
                return new ApiResponse(404, "Favorite not found");
            }

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return new ApiResponse(200, "Favorite removed successfully");
        }
        public async Task<List<BusinessModel>> GetFavoritesForUserAsync(Guid userId)
        {
            return await _context.Favorites
                .Where(f => f.Id == userId)
                .Select(f => f.Business)
                .ToListAsync();
        }
        public async Task<bool> IsFavoriteAsync(Guid userId, Guid businessId)
        {
            return await _context.Favorites
                .AnyAsync(f => f.Id == userId && f.BusinessId == businessId);
        }


    }
}
