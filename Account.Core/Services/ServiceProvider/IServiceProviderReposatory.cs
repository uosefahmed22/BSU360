using Account.Apis.Errors;
using Account.Core.Dtos.ServiceProvider;
using Account.Core.Models.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.ServiceProvider
{
    public interface IServiceProviderReposatory
    {
        Task<ServicesProviderdModel> GetServiceProviderByIdAsync(Guid id);
        Task<IEnumerable<ServicesProviderdModel>> GetAllServiceProviderAsync();
        Task<ApiResponse> AddServiceProviderAsync(ServicesProviderDto serviceProviderDto);
        Task<ApiResponse> UpdateServiceProviderAsync(ServicesProviderDto serviceProviderDto, Guid serviceProviderId);
        Task<ApiResponse> DeleteServiceProviderAsync(Guid id);
    }
}
