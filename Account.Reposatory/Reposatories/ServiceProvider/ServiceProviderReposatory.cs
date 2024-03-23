using Account.Apis.Errors;
using Account.Core.Dtos.ServiceProvider;
using Account.Core.Models.ProjectBusiness.Contacts;
using Account.Core.Models.ServiceProvider;
using Account.Core.Models.ServiceProvider.ContactsServiceProvider;
using Account.Core.Services.ServiceProvider;
using Account.Reposatory.Data.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.ServiceProvider
{
    public class ServiceProviderReposatory : IServiceProviderReposatory
    {
        private readonly BusinessDbContext _context;
        public ServiceProviderReposatory(BusinessDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> AddServiceProviderAsync(ServicesProviderDto serviceProviderDto)
        {
            try
            {
                var serviceProviderModel = new ServicesProviderdModel
                {
                    NameAR = serviceProviderDto.NameAR,
                    NameENG = serviceProviderDto.NameENG,
                    AboutAR = serviceProviderDto.AboutAR,
                    AboutENG = serviceProviderDto.AboutENG,
                    ProfilePictureUrl = serviceProviderDto.ProfilePictureUrl,
                    Latitude = serviceProviderDto.Latitude,
                    Longitude = serviceProviderDto.Longitude,
                    Address = serviceProviderDto.Address,
                    WorkStartHour = serviceProviderDto.WorkStartHour,
                    WorkEndHour = serviceProviderDto.WorkEndHour,
                    WorkingDays = serviceProviderDto.WorkingDays,
                    ServiceProviderHoliday = serviceProviderDto.Holidays.Select(date => new ServiceProviderHoliday { HolidayDate = date }).ToList(),
                    ServiceProviderAlbumUrl = serviceProviderDto.AlbumUrls.Select(url => new ServiceProviderAlbumUrl { PictureUrl = url }).ToList(),
                    ServiceProviderContacts = new List<ServiceProviderContacts>
            {
                new ServiceProviderContacts
                {
                    ServiceProviderEmails = serviceProviderDto.ServicesProviderContactsDto.ServicesProviderContactsDtoEmails.Select(email => new ServiceProviderEmails { Email = email }).ToList(),
                    ServiceProviderPhoneNumbers = serviceProviderDto.ServicesProviderContactsDto.ServicesProviderContactsDtoPhoneNumbers.Select(phone => new ServiceProviderPhoneNumbers { PhoneNumber = phone }).ToList(),
                    ServiceProviderURLSites = serviceProviderDto.ServicesProviderContactsDto.ServicesProviderContactsDtoUrlSites.Select(site => new ServiceProviderURLSites { UrlSite = site }).ToList()
                }
            }
                };

                _context.ServicesProviderd.Add(serviceProviderModel);

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Service provider added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error adding service provider: {ex.Message}");
            }
        }

        public async Task<ApiResponse> DeleteServiceProviderAsync(Guid id)
        {
            try
            {
                var serviceProviderToDelete = await _context.ServicesProviderd.FindAsync(id);

                if (serviceProviderToDelete == null)
                {
                    return new ApiResponse(400, $"Service provider with ID {id} not found.");
                }

                _context.ServicesProviderd.Remove(serviceProviderToDelete);

                await _context.SaveChangesAsync();

                return new ApiResponse(200, $"Service provider with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error deleting service provider: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ServicesProviderdModel>> GetAllServiceProviderAsync()
        {
            var response = await _context.ServicesProviderd
                .Include(s => s.ServiceProviderHoliday)
                .Include(s => s.ServiceProviderAlbumUrl)
                .Include(s => s.ServiceProviderContacts).ThenInclude(c => c.ServiceProviderEmails)
                .Include(s => s.ServiceProviderContacts).ThenInclude(c => c.ServiceProviderPhoneNumbers)
                .Include(s => s.ServiceProviderContacts).ThenInclude(c => c.ServiceProviderURLSites)
                .ToListAsync();

            return response;
        }


        public async Task<ServicesProviderdModel> GetServiceProviderByIdAsync(Guid id)
        {
            return await _context.ServicesProviderd.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ApiResponse> UpdateServiceProviderAsync(ServicesProviderDto serviceProviderDto, Guid serviceProviderId)
        {
            try
            {
                var serviceProviderModel = await _context.ServicesProviderd
                    .Include(s => s.ServiceProviderHoliday)
                    .Include(s => s.ServiceProviderContacts)
                    .Include(s => s.ServiceProviderAlbumUrl)
                    .FirstOrDefaultAsync(s => s.Id == serviceProviderId);

                if (serviceProviderModel == null)
                {
                    return new ApiResponse
                    {
                        StatusCode = 404,
                        Message = $"Service provider with ID {serviceProviderId} not found."
                    };
                }

                serviceProviderModel.NameAR = serviceProviderDto.NameAR;
                serviceProviderModel.NameENG = serviceProviderDto.NameENG;
                serviceProviderModel.AboutAR = serviceProviderDto.AboutAR;
                serviceProviderModel.AboutENG = serviceProviderDto.AboutENG;
                serviceProviderModel.ProfilePictureUrl = serviceProviderDto.ProfilePictureUrl;
                serviceProviderModel.Latitude = serviceProviderDto.Latitude;
                serviceProviderModel.Longitude = serviceProviderDto.Longitude;
                serviceProviderModel.Address = serviceProviderDto.Address;
                serviceProviderModel.WorkStartHour = serviceProviderDto.WorkStartHour;
                serviceProviderModel.WorkEndHour = serviceProviderDto.WorkEndHour;
                serviceProviderModel.WorkingDays = serviceProviderDto.WorkingDays;

                serviceProviderModel.ServiceProviderHoliday.Clear();
                foreach (var date in serviceProviderDto.Holidays)
                {
                    serviceProviderModel.ServiceProviderHoliday.Add(new ServiceProviderHoliday { HolidayDate = date });
                }

                var contactInfo = serviceProviderDto.ServicesProviderContactsDto;
                var existingContacts = serviceProviderModel.ServiceProviderContacts.FirstOrDefault();
                if (existingContacts != null)
                {
                    existingContacts.ServiceProviderEmails.Clear();
                    existingContacts.ServiceProviderPhoneNumbers.Clear();
                    existingContacts.ServiceProviderURLSites.Clear();
                }
                else
                {
                    existingContacts = new ServiceProviderContacts();
                    serviceProviderModel.ServiceProviderContacts.Add(existingContacts);
                }

                existingContacts.ServiceProviderEmails = contactInfo.ServicesProviderContactsDtoEmails.Select(email => new ServiceProviderEmails { Email = email }).ToList();
                existingContacts.ServiceProviderPhoneNumbers = contactInfo.ServicesProviderContactsDtoPhoneNumbers.Select(phone => new ServiceProviderPhoneNumbers { PhoneNumber = phone }).ToList();
                existingContacts.ServiceProviderURLSites = contactInfo.ServicesProviderContactsDtoUrlSites.Select(site => new ServiceProviderURLSites { UrlSite = site }).ToList();

                serviceProviderModel.ServiceProviderAlbumUrl.Clear();
                foreach (var url in serviceProviderDto.AlbumUrls)
                {
                    serviceProviderModel.ServiceProviderAlbumUrl.Add(new ServiceProviderAlbumUrl { PictureUrl = url });
                }

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Service provider updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error updating service provider: {ex.Message}");
            }
        }

    }
}
