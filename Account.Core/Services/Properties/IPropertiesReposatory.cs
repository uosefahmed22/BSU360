using Account.Apis.Errors;
using Account.Core.Dtos.Properties;
using Account.Core.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Properties
{
    public interface IPropertiesReposatory
    {
        Task<PropertiesDto> GetPropertyByIdAsync(Guid id);
        Task<IEnumerable<PropertiesDto>> GetAllPropertiesAsync();
        Task<ApiResponse> AddPropertyAsync(PropertiesDto propertyDto);
        Task<ApiResponse> UpdatePropertyAsync(PropertiesDto propertyDto, Guid propertyId);
        Task<ApiResponse> DeletePropertyAsync(Guid id);
    }
}
