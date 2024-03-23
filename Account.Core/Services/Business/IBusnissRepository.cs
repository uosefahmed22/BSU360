using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Models.Projectbusiness;
using Account.Core.Models.ProjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Business
{
    public interface IBusnissRepository
    {
        Task<BusinessModel> GetByIdAsync(Guid id);
        Task<IEnumerable<BusinessModel>> GetAllAsync();
        Task<ApiResponse> AddBusinessAsync(BusinessDto businessDto);
        Task<ApiResponse> UpdateBusinessAsync(BusinessDto businessDto, Guid businessId);
        Task<ApiResponse> DeleteAsync(Guid id);
    }   
}
