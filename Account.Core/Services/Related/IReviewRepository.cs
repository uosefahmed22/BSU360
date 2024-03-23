using Account.Apis.Errors;
using Account.Core.Models.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Related
{
    public interface IReviewRepository
    {
        Task<Review> GetReviewByIdAsync(Guid id);
        Task<List<Review>> GetAllReviewsAsync();
        Task<List<Review>> GetReviewsForBusinessAsync(Guid businessId);
        Task<ApiResponse> AddReviewAsync(Guid businessId, string reviewText);
        Task<ApiResponse> UpdateReviewAsync(Guid reviewId, string updatedReviewText);
        Task<ApiResponse> DeleteReviewAsync(Guid id);
    }
}
