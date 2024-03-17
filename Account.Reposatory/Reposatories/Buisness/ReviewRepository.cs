using Account.Apis.Errors;
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
    public class ReviewRepository : IReviewRepository
    {
        private readonly BusinessDbContext _context;

        public ReviewRepository(BusinessDbContext context )
        {
            _context = context;
        }
        public async Task<ApiResponse> AddReviewAsync(Guid businessId, string reviewText)
        {
            if (string.IsNullOrWhiteSpace(reviewText))
            {
                return new ApiResponse(400, "Review text is required");
            }

            var review = new Review
            {
                BusinessId = businessId,
                Text = reviewText
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return new ApiResponse(200, "Review added successfully");
        }
        public async Task<ApiResponse> DeleteReviewAsync(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return new ApiResponse(404, "Review not found");
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return new ApiResponse(200, "Review deleted successfully");
        }
        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }
        public async Task<Review> GetReviewByIdAsync(Guid id)
        {
            return await _context.Reviews.FindAsync(id);
        }
        public async Task<List<Review>> GetReviewsForBusinessAsync(Guid businessId)
        {
            return await _context.Reviews
                .Where(r => r.BusinessId == businessId)
                .ToListAsync();
        }
        public async Task<ApiResponse> UpdateReviewAsync(Guid reviewId, string updatedReviewText)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return new ApiResponse(404, "Review not found");
            }

            review.Text = updatedReviewText;
            await _context.SaveChangesAsync();

            return new ApiResponse(200, "Review updated successfully");
        }


    }
}
