using Account.Core.Services.Related;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers.Related
{
    public class RatingController : ApiBaseController
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        [HttpPost("AddRating/{businessId}/{value}/{userId}")]
        public async Task<IActionResult> AddRating(Guid businessId, int value, Guid userId)
        {
            try
            {
                var response = await _ratingRepository.AddRatingAsync(businessId, value, userId);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the rating: {ex.Message}");
            }
        }

        [HttpDelete("DeleteRating/{id}")]
        public async Task<IActionResult> DeleteRating(Guid id)
        {
            try
            {
                var response = await _ratingRepository.DeleteRatingAsync(id);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the rating: {ex.Message}");
            }
        }

        [HttpGet("GetAllRatings")]
        public async Task<IActionResult> GetAllRatings()
        {
            try
            {
                var ratings = await _ratingRepository.GetAllRatingsAsync();
                return Ok(ratings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching ratings: {ex.Message}");
            }
        }

        [HttpGet("GetRatingById/{id}")]
        public async Task<IActionResult> GetRatingById(Guid id)
        {
            try
            {
                var rating = await _ratingRepository.GetRatingByIdAsync(id);
                if (rating == null)
                {
                    return NotFound("Rating not found");
                }
                return Ok(rating);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the rating: {ex.Message}");
            }
        }

        [HttpGet("GetAverageRating/{businessId}")]
        public async Task<IActionResult> GetAverageRatingForBusiness(Guid businessId)
        {
            try
            {
                var averageRating = await _ratingRepository.GetAverageRatingForBusinessAsync(businessId);
                return Ok(averageRating);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the average rating: {ex.Message}");
            }
        }

        [HttpPut("UpdateRating/{businessId}/{value}/{userId}")]
        public async Task<IActionResult> UpdateRating(Guid businessId, int value, Guid userId)
        {
            try
            {
                var response = await _ratingRepository.UpdateRatingAsync(businessId, value, userId);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the rating: {ex.Message}");
            }
        }

    }
}
