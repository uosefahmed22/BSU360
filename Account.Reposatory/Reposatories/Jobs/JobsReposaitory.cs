using Account.Apis.Errors;
using Account.Core.Dtos.Jobs;
using Account.Core.Models.Jobs.Contacts;
using Account.Core.Models.Jobs;
using Account.Core.Models.Properties.Contacts;
using Account.Core.Services.Jobs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Reposatory.Data.Business;
using Account.Core.Dtos.Business.ContactsGertAll;

namespace Account.Reposatory.Reposatories.Jobs
{
    public class JobsReposaitory : IJobsReposaitory
    {
        private readonly BusinessDbContext _context;

        public JobsReposaitory(BusinessDbContext context)
        {
           _context = context;
        }
        public async Task<ApiResponse> AddJobAsync(JobsDto jobDto)
        {
            try
            {
                var jobModel = new JobsModel
                {
                    CompanyNameOrLocationArabic = jobDto.CompanyNameOrLocationArabic,
                    CompanyNameOrLocationEnglish = jobDto.CompanyNameOrLocationEnglish,
                    JobDetailsArabic = jobDto.JobDetailsArabic,
                    JobDetailsEnglish = jobDto.JobDetailsEnglish,
                    AddressArabic = jobDto.AddressArabic,
                    AddressEnglish = jobDto.AddressEnglish,
                    ApplicationRequirementsArabic = jobDto.ApplicationRequirementsArabic,
                    ApplicationRequirementsEnglish = jobDto.ApplicationRequirementsEnglish,
                    Salary = jobDto.Salary,
                    JobsModelContacts = new List<JobsModelContacts>
            {
                new JobsModelContacts
                {
                    JobsModelEmails = jobDto.Contacts?.Emails.Select(email => new JobsModelEmails { Email = email }).ToList() ?? new List<JobsModelEmails>(),
                    JobsModelPhoneNumbers = jobDto.Contacts?.PhoneNumbers.Select(phone => new JobsModelPhoneNumbers { PhoneNumber = phone }).ToList() ?? new List<JobsModelPhoneNumbers>(),
                    JobsModelURLSites = jobDto.Contacts?.UrlSites.Select(site => new JobsModelURLSites { UrlSite = site }).ToList() ?? new List<JobsModelURLSites>()
                }
            }
                };

                _context.JobsModel.Add(jobModel);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Job added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error adding job: {ex.Message}");
            }
        }

        public async Task<ApiResponse> DeleteJobAsync(Guid id)
        {
            try
            {
                var jobToDelete = await _context.JobsModel.FindAsync(id);

                if (jobToDelete == null)
                {
                    return new ApiResponse(400, $"Job with ID {id} not found.");
                }

                _context.JobsModel.Remove(jobToDelete);

                await _context.SaveChangesAsync();

                return new ApiResponse(200, $"Job with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error deleting job: {ex.Message}");
            }
        }

        public async Task<IEnumerable<JobsDto>> GetAllJobsAsync()
        {
            var response = await _context.JobsModel
                .Include(j => j.JobsModelContacts).ThenInclude(c => c.JobsModelEmails)
                .Include(j => j.JobsModelContacts).ThenInclude(c => c.JobsModelPhoneNumbers)
                .Include(j => j.JobsModelContacts).ThenInclude(c => c.JobsModelURLSites)
                .ToListAsync();

            var jobsDtoList = response.Select(job => new JobsDto
            {
                Id = job.Id,
                CompanyNameOrLocationArabic = job.CompanyNameOrLocationArabic,
                CompanyNameOrLocationEnglish = job.CompanyNameOrLocationEnglish,
                JobDetailsArabic = job.JobDetailsArabic,
                JobDetailsEnglish = job.JobDetailsEnglish,
                AddressArabic = job.AddressArabic,
                AddressEnglish = job.AddressEnglish,
                ApplicationRequirementsArabic = job.ApplicationRequirementsArabic,
                ApplicationRequirementsEnglish = job.ApplicationRequirementsEnglish,
                Salary = job.Salary,
                Contacts = new JobContactDto
                {
                    Id = job.Id,
                    Emails = job.JobsModelContacts.SelectMany(c => c.JobsModelEmails.Select(e => e.Email)).ToList(),
                    PhoneNumbers = job.JobsModelContacts.SelectMany(c => c.JobsModelPhoneNumbers.Select(p => p.PhoneNumber)).ToList(),
                    UrlSites = job.JobsModelContacts.SelectMany(c => c.JobsModelURLSites.Select(u => u.UrlSite)).ToList()
                }
            }).ToList();

            return jobsDtoList;
        }

        public async Task<JobsDto> GetJobByIdAsync(Guid id)
        {
            var job = await _context.JobsModel
                .Include(j => j.JobsModelContacts).ThenInclude(c => c.JobsModelEmails)
                .Include(j => j.JobsModelContacts).ThenInclude(c => c.JobsModelPhoneNumbers)
                .Include(j => j.JobsModelContacts).ThenInclude(c => c.JobsModelURLSites)
                .FirstOrDefaultAsync(j => j.Id == id);

            if (job == null)
            {
                return null;
            }

            var jobDto = new JobsDto
            {
                Id = job.Id,
                CompanyNameOrLocationArabic = job.CompanyNameOrLocationArabic,
                CompanyNameOrLocationEnglish = job.CompanyNameOrLocationEnglish,
                JobDetailsArabic = job.JobDetailsArabic,
                JobDetailsEnglish = job.JobDetailsEnglish,
                AddressArabic = job.AddressArabic,
                AddressEnglish = job.AddressEnglish,
                ApplicationRequirementsArabic = job.ApplicationRequirementsArabic,
                ApplicationRequirementsEnglish = job.ApplicationRequirementsEnglish,
                Salary = job.Salary,
                Contacts = job.JobsModelContacts.Select(contact => new JobContactDto
                {
                    Id = contact.Id,
                    Emails = contact.JobsModelEmails.Select(email => email.Email).ToList(),
                    PhoneNumbers = contact.JobsModelPhoneNumbers.Select(phone => phone.PhoneNumber).ToList(),
                    UrlSites = contact.JobsModelURLSites.Select(url => url.UrlSite).ToList()
                }).FirstOrDefault()
            };

            return jobDto;
        }

        public async Task<ApiResponse> UpdateJobAsync(JobsDto jobDto, Guid jobId)
        {
            try
            {
                var jobModel = await _context.JobsModel
                    .Include(j => j.JobsModelContacts).ThenInclude(c => c.JobsModelEmails)
                    .Include(j => j.JobsModelContacts).ThenInclude(c => c.JobsModelPhoneNumbers)
                    .Include(j => j.JobsModelContacts).ThenInclude(c => c.JobsModelURLSites)
                    .FirstOrDefaultAsync(j => j.Id == jobId);

                if (jobModel == null)
                {
                    return new ApiResponse
                    {
                        StatusCode = 404,
                        Message = $"Job with ID {jobId} not found."
                    };
                }

                jobModel.CompanyNameOrLocationArabic = jobDto.CompanyNameOrLocationArabic;
                jobModel.CompanyNameOrLocationEnglish = jobDto.CompanyNameOrLocationEnglish;
                jobModel.JobDetailsArabic = jobDto.JobDetailsArabic;
                jobModel.JobDetailsEnglish = jobDto.JobDetailsEnglish;
                jobModel.AddressArabic = jobDto.AddressArabic;
                jobModel.AddressEnglish = jobDto.AddressEnglish;
                jobModel.ApplicationRequirementsArabic = jobDto.ApplicationRequirementsArabic;
                jobModel.ApplicationRequirementsEnglish = jobDto.ApplicationRequirementsEnglish;
                jobModel.Salary = jobDto.Salary;

                var contactInfo = jobDto.Contacts;
                var existingContacts = jobModel.JobsModelContacts.FirstOrDefault();
                if (existingContacts != null)
                {
                    existingContacts.JobsModelEmails.Clear();
                    existingContacts.JobsModelPhoneNumbers.Clear();
                    existingContacts.JobsModelURLSites.Clear();
                }
                else
                {
                    existingContacts = new JobsModelContacts();
                    jobModel.JobsModelContacts.Add(existingContacts);
                }

                existingContacts.JobsModelEmails = contactInfo.Emails.Select(email => new JobsModelEmails { Email = email }).ToList();
                existingContacts.JobsModelPhoneNumbers = contactInfo.PhoneNumbers.Select(phone => new JobsModelPhoneNumbers { PhoneNumber = phone }).ToList();
                existingContacts.JobsModelURLSites = contactInfo.UrlSites.Select(site => new JobsModelURLSites { UrlSite = site }).ToList();

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Job updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Error updating job: {ex.Message}");
            }
        }


    }
}
