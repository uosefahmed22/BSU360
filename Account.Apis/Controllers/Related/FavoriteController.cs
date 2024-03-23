using Account.Core.Services.Related;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers.Related
{
    public class FavoriteController : ApiBaseController
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        [HttpPost("AddFavorite/{userId}/{businessId}")]
        public async Task<IActionResult> AddFavorite(Guid userId, Guid businessId)
        {
            try
            {
                var response = await _favoriteRepository.AddFavoriteAsync(userId, businessId);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the favorite: {ex.Message}");
            }
        }

        [HttpDelete("RemoveFavorite/{userId}/{businessId}")]
        public async Task<IActionResult> RemoveFavorite(Guid userId, Guid businessId)
        {
            try
            {
                var response = await _favoriteRepository.RemoveFavoriteAsync(userId, businessId);
                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while removing the favorite: {ex.Message}");
            }
        }

        [HttpGet("GetFavoritesForUser/{userId}")]
        public async Task<IActionResult> GetFavoritesForUser(Guid userId)
        {
            try
            {
                var favorites = await _favoriteRepository.GetFavoritesForUserAsync(userId);
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching favorites: {ex.Message}");
            }
        }

        [HttpGet("IsFavorite/{userId}/{businessId}")]
        public async Task<IActionResult> IsFavorite(Guid userId, Guid businessId)
        {
            try
            {
                var isFavorite = await _favoriteRepository.IsFavoriteAsync(userId, businessId);
                return Ok(isFavorite);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while checking favorite status: {ex.Message}");
            }
        }



    }
}
