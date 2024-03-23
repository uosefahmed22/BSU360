using Account.Core.Models.ProjectBusiness;
using Account.Core.Services.Related;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers.Related
{
    public class ReviewController : ApiBaseController
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        [HttpPost("AddReview/{businessId}")]
        public async Task<IActionResult> AddReview(Guid businessId, [FromBody] string reviewText)
        {
            try
            {
                var response = await _reviewRepository.AddReviewAsync(businessId, reviewText);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the review: {ex.Message}");
            }
        }

        [HttpDelete("DeleteReview/{id}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            try
            {
                var response = await _reviewRepository.DeleteReviewAsync(id);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the review: {ex.Message}");
            }
        }

        [HttpGet("GetAllReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                var reviews = await _reviewRepository.GetAllReviewsAsync();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching reviews: {ex.Message}");
            }
        }

        [HttpGet("GetReviewById/{id}")]
        public async Task<IActionResult> GetReviewById(Guid id)
        {
            try
            {
                var review = await _reviewRepository.GetReviewByIdAsync(id);
                if (review == null)
                {
                    return NotFound($"Review with ID {id} not found");
                }
                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the review: {ex.Message}");
            }
        }

        [HttpGet("GetReviewsForBusiness/{businessId}")]
        public async Task<IActionResult> GetReviewsForBusiness(Guid businessId)
        {
            try
            {
                var reviews = await _reviewRepository.GetReviewsForBusinessAsync(businessId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching reviews for the business: {ex.Message}");
            }
        }

        [HttpPut("UpdateReview/{reviewId}")]
        public async Task<IActionResult> UpdateReview(Guid reviewId, [FromBody] string updatedReviewText)
        {
            try
            {
                var response = await _reviewRepository.UpdateReviewAsync(reviewId, updatedReviewText);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the review: {ex.Message}");
            }
        }

    }
}
