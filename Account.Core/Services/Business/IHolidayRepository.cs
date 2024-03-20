using Account.Apis.Errors;
using Account.Core.Models.ProjectBusiness.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Business
{
    public interface IHolidayRepository
    {
        Task<Holiday> GetHolidayByIdAsync(int id);
        Task<List<Holiday>> GetAllHolidaysAsync();
        Task<List<Holiday>> GetHolidaysForBusinessAsync(Guid businessId);
        Task<ApiResponse> AddHolidayAsync(Guid businessId, DateTime holidayDate);
        Task<ApiResponse> UpdateHolidayAsync(int id, Guid businessId, DateTime holidayDate);
        Task<ApiResponse> DeleteHolidayAsync(int id);
    }

}
