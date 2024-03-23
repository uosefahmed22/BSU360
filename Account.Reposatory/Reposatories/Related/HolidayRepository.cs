using Account.Apis.Errors;
using Account.Core.Models.ProjectBusiness;
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
    public class HolidayRepository : IHolidayRepository
    {
        private readonly BusinessDbContext _context;

        public HolidayRepository(BusinessDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse> AddHolidayAsync(Guid businessId, DateTime holidayDate)
        {
            try
            {
                var business = await _context.Businesses.FindAsync(businessId);
                if (business == null)
                {
                    return new ApiResponse(404, "Business not found");
                }

                var existingHoliday = await _context.Holidays
                    .FirstOrDefaultAsync(h => h.BusinessId == businessId && h.HolidayDate.Date == holidayDate.Date);

                if (existingHoliday != null)
                {
                    return new ApiResponse(400, "Holiday date already exists for the business");
                }

                var holiday = new Holiday
                {
                    BusinessId = businessId,
                    HolidayDate = holidayDate
                };

                _context.Holidays.Add(holiday);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Holiday added successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"An error occurred while adding the holiday: {ex.Message}");
            }
        }
        public async Task<ApiResponse> DeleteHolidayAsync(int id)
        {
            try
            {
                var holiday = await _context.Holidays.FindAsync(id);
                if (holiday == null)
                {
                    return new ApiResponse(404, "Holiday not found");
                }

                _context.Holidays.Remove(holiday);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Holiday deleted successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"An error occurred while deleting the holiday: {ex.Message}");
            }
        }
        public async Task<List<Holiday>> GetAllHolidaysAsync()
        {
            return await _context.Holidays.ToListAsync();
        }
        public async Task<Holiday> GetHolidayByIdAsync(int id)
        {
            return await _context.Holidays.FindAsync(id);
        }
        public async Task<List<Holiday>> GetHolidaysForBusinessAsync(Guid businessId)
        {
            return await _context.Holidays
                .Where(h => h.BusinessId == businessId)
                .ToListAsync();
        }
        public async Task<ApiResponse> UpdateHolidayAsync(int id, Guid businessId, DateTime holidayDate)
        {
            try
            {
                var holiday = await _context.Holidays.FindAsync(id);
                if (holiday == null)
                {
                    return new ApiResponse(404, "Holiday not found");
                }

                // Check if another holiday with the same date already exists for the same business
                var existingHoliday = await _context.Holidays.FirstOrDefaultAsync(h => h.BusinessId == businessId && h.HolidayDate == holidayDate && h.Id != id);
                if (existingHoliday != null)
                {
                    return new ApiResponse(400, "Another holiday with the same date already exists for the specified business");
                }

                if (holiday.BusinessId != businessId)
                {
                    return new ApiResponse(400, "Holiday does not belong to the specified business");
                }

                holiday.HolidayDate = holidayDate;

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Holiday updated successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"An error occurred while updating the holiday: {ex.Message}");
            }
        }
    }
}
