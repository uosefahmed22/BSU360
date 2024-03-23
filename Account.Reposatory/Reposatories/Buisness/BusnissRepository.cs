using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Dtos.Business.ContactsGertAll;
using Account.Core.Models.Projectbusiness;
using Account.Core.Models.ProjectBusiness;
using Account.Core.Models.ProjectBusiness.Contacts;
using Account.Core.Services.Business;
using Account.Reposatory.Data.Business;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.Buisness
{
    public class BusnissRepository : IBusnissRepository
    {
        private readonly BusinessDbContext _context;
        public BusnissRepository(BusinessDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse> AddBusinessAsync(BusinessDto businessDto)
        {
            try
            {
                var validCategoryId = await _context.Categories.AnyAsync(c => c.Id == businessDto.CategoryId);
                if (!validCategoryId)
                {
                    return new ApiResponse
                    {
                        StatusCode = 400,
                        Message = $"Invalid Category ID: {businessDto.CategoryId}."
                    };
                }

                var businessModel = new BusinessModel
                {
                    NameAR = businessDto.NameAR,
                    NameENG = businessDto.NameENG,
                    AboutAR = businessDto.AboutAR,
                    AboutENG = businessDto.AboutENG,
                    ProfilePictureUrl = businessDto.ProfilePictureUrl,
                    Latitude = businessDto.Latitude,
                    Longitude = businessDto.Longitude,
                    Address = businessDto.Address,
                    WorkStartHour = businessDto.WorkStartHour,
                    WorkEndHour = businessDto.WorkEndHour,
                    WorkingDays = businessDto.WorkingDays,
                    CategoryId = businessDto.CategoryId,
                    Holidays = businessDto.Holidays.Select(date => new Holiday { HolidayDate = date }).ToList(),
                    AlbumUrls = businessDto.AlbumUrls.Select(url => new BusinessAlbumUrl { PictureUrl = url }).ToList(),
                    Contacts = new List<Contacts>
            {
                new Contacts
                {
                    Emails = businessDto.Contacts.Emails.Select(email => new Emails { Email = email }).ToList(),
                    PhoneNumbers = businessDto.Contacts.PhoneNumbers.Select(phone => new PhoneNumbers { PhoneNumber = phone }).ToList(),
                    URlSites = businessDto.Contacts.UrlSites.Select(site => new URlSites { UrlSite = site }).ToList()
                }
            }
                };

                _context.Businesses.Add(businessModel);

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Business added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error adding business: {ex.Message}");
            }
        }

        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            try
            {
                var businessToDelete = await _context.Businesses.FindAsync(id);

                if (businessToDelete == null)
                {
                    return new ApiResponse(400, $"Business with ID {id} not found.");
                }

                // Remove related Holidays first
                _context.Holidays.RemoveRange(businessToDelete.Holidays);

                // Now delete the Business
                _context.Businesses.Remove(businessToDelete);

                await _context.SaveChangesAsync();

                return new ApiResponse(200, $"Business with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error deleting business: {ex.Message}");
            }
        }

        public async Task<IEnumerable<BusinessModel>> GetAllAsync()
        {
            var reponse = await _context.Businesses.Include(b => b.Holidays).Include(b => b.AlbumUrls)
                .Include(b => b.Contacts).ThenInclude(c => c.Emails).Include(b => b.Contacts).ThenInclude(c => c.PhoneNumbers).Include(b => b.Contacts).ThenInclude(c => c.URlSites)
                .ToListAsync();
            return reponse;
        }

        public async Task<BusinessModel> GetByIdAsync(Guid id)
        {
            return await _context.Businesses.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<ApiResponse> UpdateBusinessAsync(BusinessDto businessDto, Guid businessId)
        {
            try
            {
                var businessModel = await _context.Businesses
                    .Include(b => b.Holidays)
                    .Include(b => b.Contacts)
                    .Include(b => b.AlbumUrls) // Include AlbumUrls for update
                    .FirstOrDefaultAsync(b => b.Id == businessId);

                if (businessModel == null)
                {
                    return new ApiResponse
                    {
                        StatusCode = 404,
                        Message = $"Business with ID {businessId} not found."
                    };
                }

                // Update business properties
                businessModel.NameAR = businessDto.NameAR;
                businessModel.NameENG = businessDto.NameENG;
                businessModel.AboutAR = businessDto.AboutAR;
                businessModel.AboutENG = businessDto.AboutENG;
                businessModel.ProfilePictureUrl = businessDto.ProfilePictureUrl;
                businessModel.Latitude = businessDto.Latitude;
                businessModel.Longitude = businessDto.Longitude;
                businessModel.Address = businessDto.Address;
                businessModel.WorkStartHour = businessDto.WorkStartHour;
                businessModel.WorkEndHour = businessDto.WorkEndHour;
                businessModel.WorkingDays = businessDto.WorkingDays;
                businessModel.CategoryId = businessDto.CategoryId;

                _context.Businesses.Update(businessModel);
                await _context.SaveChangesAsync();

                // Update or add new Holidays
                businessModel.Holidays.Clear(); // Clear existing holidays
                foreach (var date in businessDto.Holidays)
                {
                    businessModel.Holidays.Add(new Holiday { HolidayDate = date });
                }

                // Update or add new Contacts
                var contactInfo = businessDto.Contacts;
                var existingContacts = businessModel.Contacts.FirstOrDefault();
                if (existingContacts != null)
                {
                    // Clear existing contact information
                    existingContacts.Emails.Clear();
                    existingContacts.PhoneNumbers.Clear();
                    existingContacts.URlSites.Clear();
                }
                else
                {
                    // Create new Contacts if not existing
                    existingContacts = new Contacts();
                    businessModel.Contacts.Add(existingContacts);
                }

                existingContacts.Emails = contactInfo.Emails.Select(email => new Emails { Email = email }).ToList();
                existingContacts.PhoneNumbers = contactInfo.PhoneNumbers.Select(phone => new PhoneNumbers { PhoneNumber = phone }).ToList();
                existingContacts.URlSites = contactInfo.UrlSites.Select(site => new URlSites { UrlSite = site }).ToList();

                // Update or add new AlbumUrls
                businessModel.AlbumUrls.Clear(); // Clear existing AlbumUrls
                foreach (var url in businessDto.AlbumUrls)
                {
                    businessModel.AlbumUrls.Add(new BusinessAlbumUrl { PictureUrl = url });
                }

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Business updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error updating business: {ex.Message}");
            }
        }

    }

}
