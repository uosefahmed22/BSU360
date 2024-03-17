using Account.Apis.Errors;
using Account.Core.Models.Projectbusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Business
{
    public interface IFavoriteRepository
    {
        Task<ApiResponse> AddFavoriteAsync(Guid userId, Guid businessId);
        Task<ApiResponse> RemoveFavoriteAsync(Guid userId, Guid businessId);
        Task<List<BusinessModel>> GetFavoritesForUserAsync(Guid userId);
        Task<bool> IsFavoriteAsync(Guid userId, Guid businessId);
    }

}
