using Account.Apis.Errors;
using Account.Core.Models.ProjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Business
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingByIdAsync(Guid id);
        Task<List<Rating>> GetAllRatingsAsync();
        Task<double> GetAverageRatingForBusinessAsync(Guid businessId);
        Task<ApiResponse> AddRatingAsync(Guid businessId, int value, Guid userId);
        Task<ApiResponse> UpdateRatingAsync(Guid businessId, int value, Guid userId);
        Task<ApiResponse> DeleteRatingAsync(Guid id);
    }

}
