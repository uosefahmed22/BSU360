using Account.Apis.Errors;
using Account.Core.Dtos.Properties;
using Account.Core.Models.Properties;
using Account.Core.Models.Properties.Contacts;
using Account.Core.Services.Properties;
using Account.Reposatory.Data.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.Properties
{
    public class PropertiesReposatory : IPropertiesReposatory
    {
        private readonly BusinessDbContext _context;

        public PropertiesReposatory(BusinessDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse> AddPropertyAsync(PropertiesDto propertyDto)
        {
            try
            {
                var propertyModel = new PropertiesModel
                {
                    NameArabic = propertyDto.NameArabic,
                    NameEnglish = propertyDto.NameEnglish,
                    DescriptionArabic = propertyDto.DescriptionArabic,
                    DescriptionEnglish = propertyDto.DescriptionEnglish,
                    AddressArabic = propertyDto.AddressArabic,
                    AddressEnglish = propertyDto.AddressEnglish,
                    Salary = propertyDto.Salary,
                    PropertiesAlbumUrl = propertyDto.AlbumUrls.Select(url => new PropertiesAlbumUrl { PictureUrl = url }).ToList(),
                    ContactsOfProperties = new List<ContactsOfProperties>
            {
                new ContactsOfProperties
                {
                    EmailsofProperties = propertyDto.PropertiesContactsDto.Emails.Select(email => new EmailsofProperties { Email = email }).ToList(),
                    PhoneNumbersOfProperties = propertyDto.PropertiesContactsDto.PhoneNumbers
                        .Select(phone => new PhoneNumbersOfProperties { PhoneNumber = phone }).ToList(),
                    URLSitesOfProperties = propertyDto.PropertiesContactsDto.UrlSites
                        .Select(site => new URLSitesOfProperties { UrlSite = site }).ToList()
                }
            }
                };

                _context.PropertiesModel.Add(propertyModel);

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Property added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error adding property: {ex.Message}");
            }
        }
        public async Task<ApiResponse> DeletePropertyAsync(Guid id)
        {
            try
            {
                var propertyToDelete = await _context.PropertiesModel.FindAsync(id);

                if (propertyToDelete == null)
                {
                    return new ApiResponse(400, $"Property with ID {id} not found.");
                }

                _context.PropertiesModel.Remove(propertyToDelete);

                await _context.SaveChangesAsync();

                return new ApiResponse(200, $"Property with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error deleting property: {ex.Message}");
            }
        }
        public async Task<IEnumerable<PropertiesDto>> GetAllPropertiesAsync()
        {
            var response = await _context.PropertiesModel
                .Include(p => p.PropertiesAlbumUrl)
                .Include(p => p.ContactsOfProperties).ThenInclude(c => c.EmailsofProperties)
                .Include(p => p.ContactsOfProperties).ThenInclude(c => c.PhoneNumbersOfProperties)
                .Include(p => p.ContactsOfProperties).ThenInclude(c => c.URLSitesOfProperties)
                .ToListAsync();

            var propertiesDtoList = response.Select(property => new PropertiesDto
            {
                Id = property.Id,
                NameArabic = property.NameArabic,
                NameEnglish = property.NameEnglish,
                DescriptionArabic = property.DescriptionArabic,
                DescriptionEnglish = property.DescriptionEnglish,
                AddressArabic = property.AddressArabic,
                AddressEnglish = property.AddressEnglish,
                Salary = property.Salary,
                AlbumUrls = property.PropertiesAlbumUrl.Select(url => url.PictureUrl).ToList(),
                PropertiesContactsDto = new PropertiesContactsDto
                {
                    Id = property.Id,
                    Emails = property.ContactsOfProperties.SelectMany(c => c.EmailsofProperties.Select(e => e.Email)).ToList(),
                    PhoneNumbers = property.ContactsOfProperties.SelectMany(c => c.PhoneNumbersOfProperties.Select(p => p.PhoneNumber)).ToList(),
                    UrlSites = property.ContactsOfProperties.SelectMany(c => c.URLSitesOfProperties.Select(u => u.UrlSite)).ToList()
                }
            }).ToList();

            return propertiesDtoList;
        }

        public async Task<PropertiesDto> GetPropertyByIdAsync(Guid id)
        {
            var property = await _context.PropertiesModel
                .Include(p => p.PropertiesAlbumUrl)
                .Include(p => p.ContactsOfProperties).ThenInclude(c => c.EmailsofProperties)
                .Include(p => p.ContactsOfProperties).ThenInclude(c => c.PhoneNumbersOfProperties)
                .Include(p => p.ContactsOfProperties).ThenInclude(c => c.URLSitesOfProperties)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
            {
                return null;
            }

            var propertyDto = new PropertiesDto
            {
                Id = property.Id,
                NameArabic = property.NameArabic,
                NameEnglish = property.NameEnglish,
                DescriptionArabic = property.DescriptionArabic,
                DescriptionEnglish = property.DescriptionEnglish,
                AddressArabic = property.AddressArabic,
                AddressEnglish = property.AddressEnglish,
                Salary = property.Salary,
                AlbumUrls = property.PropertiesAlbumUrl.Select(url => url.PictureUrl).ToList(),
                PropertiesContactsDto = new PropertiesContactsDto
                {
                    Id = property.Id,
                    Emails = property.ContactsOfProperties.SelectMany(c => c.EmailsofProperties.Select(e => e.Email)).ToList(),
                    PhoneNumbers = property.ContactsOfProperties.SelectMany(c => c.PhoneNumbersOfProperties.Select(p => p.PhoneNumber)).ToList(),
                    UrlSites = property.ContactsOfProperties.SelectMany(c => c.URLSitesOfProperties.Select(u => u.UrlSite)).ToList()
                }
            };

            return propertyDto;
        }

        public async Task<ApiResponse> UpdatePropertyAsync(PropertiesDto propertyDto, Guid propertyId)
        {
            try
            {
                var propertyModel = await _context.PropertiesModel
                    .Include(p => p.PropertiesAlbumUrl)
                    .Include(p => p.ContactsOfProperties).ThenInclude(c => c.EmailsofProperties)
                    .Include(p => p.ContactsOfProperties).ThenInclude(c => c.PhoneNumbersOfProperties)
                    .Include(p => p.ContactsOfProperties).ThenInclude(c => c.URLSitesOfProperties)
                    .FirstOrDefaultAsync(p => p.Id == propertyId);

                if (propertyModel == null)
                {
                    return new ApiResponse
                    {
                        StatusCode = 404,
                        Message = $"Property with ID {propertyId} not found."
                    };
                }

                propertyModel.NameArabic = propertyDto.NameArabic;
                propertyModel.NameEnglish = propertyDto.NameEnglish;
                propertyModel.DescriptionArabic = propertyDto.DescriptionArabic;
                propertyModel.DescriptionEnglish = propertyDto.DescriptionEnglish;
                propertyModel.AddressArabic = propertyDto.AddressArabic;
                propertyModel.AddressEnglish = propertyDto.AddressEnglish;
                propertyModel.Salary = propertyDto.Salary;

                propertyModel.PropertiesAlbumUrl.Clear();
                foreach (var url in propertyDto.AlbumUrls)
                {
                    propertyModel.PropertiesAlbumUrl.Add(new PropertiesAlbumUrl { PictureUrl = url });
                }

                var contactInfo = propertyDto.PropertiesContactsDto;
                var existingContacts = propertyModel.ContactsOfProperties.FirstOrDefault();
                if (existingContacts != null)
                {
                    existingContacts.EmailsofProperties.Clear();
                    existingContacts.PhoneNumbersOfProperties.Clear();
                    existingContacts.URLSitesOfProperties.Clear();
                }
                else
                {
                    existingContacts = new ContactsOfProperties();
                    propertyModel.ContactsOfProperties.Add(existingContacts);
                }

                existingContacts.EmailsofProperties = contactInfo.Emails.Select(email => new EmailsofProperties { Email = email }).ToList();
                existingContacts.PhoneNumbersOfProperties = contactInfo.PhoneNumbers.Select(phone => new PhoneNumbersOfProperties { PhoneNumber = phone }).ToList();
                existingContacts.URLSitesOfProperties = contactInfo.UrlSites.Select(site => new URLSitesOfProperties { UrlSite = site }).ToList();

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Property updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error updating property: {ex.Message}");
            }
        }

    }
}
