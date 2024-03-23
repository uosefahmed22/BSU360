using Account.Apis.Errors;
using Account.Core.Models.Related;
using Account.Core.Services.Related;
using Account.Reposatory.Data.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.Related
{
    public class RatingRepository : IRatingRepository
    {
        private readonly BusinessDbContext _context;

        public RatingRepository(BusinessDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> AddRatingAsync(Guid businessId, int value, Guid userId)
        {
            var existingRating = await _context.Ratings
                .FirstOrDefaultAsync(r => r.BusinessId == businessId && r.Id == userId);

            if (existingRating != null)
            {
                return new ApiResponse(400, "User has already rated this business");
            }

            var rating = new Rating
            {
                BusinessId = businessId,
                Value = value,
                Id = userId
            };

            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            return new ApiResponse(200, "Rating added successfully");
        }
        public async Task<ApiResponse> DeleteRatingAsync(Guid id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                return new ApiResponse(404, "Rating not found");
            }

            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();

            return new ApiResponse(200, "Rating deleted successfully");
        }
        public async Task<List<Rating>> GetAllRatingsAsync()
        {
            return await _context.Ratings.ToListAsync();
        }
        public async Task<Rating> GetRatingByIdAsync(Guid id)
        {
            return await _context.Ratings.FindAsync(id);
        }
        public async Task<double> GetAverageRatingForBusinessAsync(Guid businessId)
        {
            var ratings = await _context.Ratings
                .Where(r => r.BusinessId == businessId)
                .Select(r => r.Value)
                .ToListAsync();

            if (ratings.Count == 0)
            {
                return 0;
            }

            double totalRating = ratings.Sum();
            double averageRating = totalRating / ratings.Count;
            return averageRating;
        }
        public async Task<ApiResponse> UpdateRatingAsync(Guid businessId, int value, Guid userId)
        {
            var existingRating = await _context.Ratings.FindAsync(userId);

            if (existingRating == null)
            {
                return new ApiResponse(404, "Rating not found");
            }

            existingRating.Value = value;

            try
            {
                await _context.SaveChangesAsync();
                return new ApiResponse(200, "Rating updated successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"An error occurred while updating the rating: {ex.Message}");
            }
        }


    }
}
