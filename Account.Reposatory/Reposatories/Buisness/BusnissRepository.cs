using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Dtos.Business.Request;
using Account.Core.Dtos.Business.Response;
using Account.Core.Errors;
using Account.Core.Models.Projectbusiness;
using Account.Core.Models.ProjectBusiness;
using Account.Core.Models.Response;
using Account.Core.Services.Business;
using Account.Reposatory.Data.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.Buisness
{
    public class BusnissRepository : IBusnissRepository
    {
        private readonly BusnissDbContext _dbContext;
        private readonly IWorkTimeService _workTimeService;

        public BusnissRepository(BusnissDbContext dbContext,IWorkTimeService workTimeService)
        {
            _dbContext = dbContext;
            _workTimeService = workTimeService;
        }
        public async Task<ApiResponse> CreateBusinessAsync(BusnisRequest request, Guid userId)
        {
            // Check if a business already exists for the given user or if the category ID is valid
            var existingBusiness = await _dbContext.Busnisses
                .Where(b => b.UserId == userId)
                .AnyAsync();

            var validCategoryId = await _dbContext.Categories
                .AnyAsync(c => c.Id == request.CategoryId);

            if (existingBusiness)
            {
                return new ApiResponse
                {
                    StatusCode = 409,
                    Message = $"User with ID: {userId} already has a business."
                };
            }

            if (!validCategoryId)
            {
                return new ApiResponse
                {
                    StatusCode = 400,
                    Message = $"Category ID: {request.CategoryId} is invalid."
                };
            }

            // Create a new business entity
            var business = new BusinessModel
            {
                UserId = userId,
                NameAR = request.Name,
                AboutAR = request.About,
                CategoryId = request.CategoryId,
                Location = new()
                {
                    Address = request.Location.Address,
                    Latitude = request.Location.Latitude,
                    Longitude = request.Location.Longitude
                },
                ContactInfo = new()
                {
                    FirstPhoneNumber = request.ContactInfo.FirstPhoneNumber,
                    SecondPhoneNumber = request.ContactInfo.SecondPhoneNumber,
                    ThirdPhoneNumber = request.ContactInfo.ThirdPhoneNumber,
                    EmailAddress = request.ContactInfo.EmailAddress,
                    SiteUrl = request.ContactInfo.SiteUrl
                }
            };

            // Set business work time
            business.WorkTimes = WorkTime.SetBusinessWorkTime(request.WorkTime, business.Id).ToList();

            // Add business to the context and save changes
            _dbContext.Busnisses.Add(business);

            try
            {
                await _dbContext.SaveChangesAsync();
                return new ApiResponse(200, business.Id.ToString());
            }
            catch (DbUpdateException ex)
            {
                // Handle database-related errors
                return new ApiResponse(500, "An error occurred while saving the business entity. Please try again later.");
            }
        }

        public async Task<ApiResponse> CreateCategoryAsync(CategoryDto categoryDto)
        {
            try
            {
                var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == categoryDto.Name);
                if (existingCategory != null)
                {
                    return new ApiResponse(409, $"Category with name '{categoryDto.Name}' already exists.");
                }

                var category = new Category
                {
                    Name = categoryDto.Name,
                    PictureUrl = categoryDto.PictureUrl
                };

                // Save the category to the database
                _dbContext.Categories.Add(category);
                await _dbContext.SaveChangesAsync();

                return new ApiResponse(200, "Category created successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"An error occurred while creating the category: {ex.Message}");
            }
        }

        public async Task<ApiResponse> UpdateBusinessAsync(BusinessUpdateRequest request, Guid ownerId)
        {
            var busniss = await _dbContext.Busnisses
                .Include(b => b.Location)
                .Include(b => b.ContactInfo)
                .FirstOrDefaultAsync(b => b.Id == request.Id);

            ItemNotFoundException.ThrowIfNull(busniss, nameof(busniss));

            if (busniss.UserId != ownerId)
            {
                return new ApiResponse(401);
            }

            busniss.NameAR = request.Name;
            busniss.AboutAR = request.About;
            busniss.Location!.Latitude = request.Location.Latitude;
            busniss.Location.Longitude = request.Location.Longitude;
            busniss.Location.Address = request.Location.Address;
            busniss.ContactInfo!.FirstPhoneNumber = request.ContactInfo.FirstPhoneNumber;
            busniss.ContactInfo.SecondPhoneNumber = request.ContactInfo.SecondPhoneNumber;
            busniss.ContactInfo.ThirdPhoneNumber = request.ContactInfo.ThirdPhoneNumber;
            busniss.ContactInfo.EmailAddress = request.ContactInfo.EmailAddress;
            busniss.ContactInfo.SiteUrl = request.ContactInfo.SiteUrl;


            _dbContext.Busnisses.Update(busniss);

            await _dbContext.SaveChangesAsync();

            var days = request.WorkTime.Select(wt => wt.Day).ToList();

            await _dbContext.Entry(busniss).Collection(b => b.WorkTimes).LoadAsync();

            foreach (var wt in busniss.WorkTimes)
            {
                if (days.Contains(wt.Day))
                {
                    wt.Start = request.WorkTime.First(wtd => wtd.Day == wt.Day).Start;
                    wt.End = request.WorkTime.First(wtd => wtd.Day == wt.Day).End;
                    await _workTimeService.Update(wt);
                }
                else
                {
                    await _workTimeService.Remove(wt);
                }
            }
            foreach (var wt in request.WorkTime)
            {
                var exsists = busniss.WorkTimes.Any(bwt => bwt.Day == wt.Day);
                if (!exsists)
                {
                    await _workTimeService.Add(wt, busniss.Id);
                }
            }
            return new ApiResponse(200);
        }



        public Task<ApiResponse> UpdateCategoryAsync(CategoryUpdateRequest request, Guid CategoeryId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteAsync(Guid id, Guid ownerId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<BusnissReponse>> GetAllBusnissWithCategoryIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<BusnissReponse>> GetRecommendedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Paganate(int pageNumber, int pageSize, Guid categoryId)
        {
            throw new NotImplementedException();
        }

       
       
    }
}
