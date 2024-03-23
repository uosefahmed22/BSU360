using Account.Core.Models.ProjectBusiness;
using Account.Core.Services.Related;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers.Related
{
    public class HolidayController : ApiBaseController
    {
        private readonly IHolidayRepository _holidayRepository;

        public HolidayController(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }
        [HttpPost("AddHoliday/{businessId}")]
        public async Task<IActionResult> AddHoliday(Guid businessId, [FromBody] DateTime holidayDate)
        {
            try
            {
                var response = await _holidayRepository.AddHolidayAsync(businessId, holidayDate);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the holiday: {ex.Message}");
            }
        }

        [HttpDelete("DeleteHoliday/{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            try
            {
                var response = await _holidayRepository.DeleteHolidayAsync(id);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the holiday: {ex.Message}");
            }
        }

        [HttpGet("GetAllHolidays")]
        public async Task<IActionResult> GetAllHolidays()
        {
            try
            {
                var holidays = await _holidayRepository.GetAllHolidaysAsync();
                return Ok(holidays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving holidays: {ex.Message}");
            }
        }

        [HttpGet("GetHoliday/{id}")]
        public async Task<IActionResult> GetHolidayById(int id)
        {
            try
            {
                var holiday = await _holidayRepository.GetHolidayByIdAsync(id);
                if (holiday == null)
                {
                    return NotFound("Holiday not found");
                }
                return Ok(holiday);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the holiday: {ex.Message}");
            }
        }

        [HttpGet("GetHolidaysForBusiness/{businessId}")]
        public async Task<IActionResult> GetHolidaysForBusiness(Guid businessId)
        {
            try
            {
                var holidays = await _holidayRepository.GetHolidaysForBusinessAsync(businessId);
                return Ok(holidays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving holidays for business {businessId}: {ex.Message}");
            }
        }

        [HttpPut("UpdateHoliday/{id}/{businessId}")]
        public async Task<IActionResult> UpdateHoliday(int id, Guid businessId, [FromBody] HolidayUpdateModel model)
        {
            try
            {
                var response = await _holidayRepository.UpdateHolidayAsync(id, businessId, model.HolidayDate);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the holiday: {ex.Message}");
            }
        }
    }
}
