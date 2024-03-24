using Account.Apis.Errors;
using Account.Core.Dtos.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Jobs
{
    public interface IJobsReposaitory
    {
        Task<JobsDto> GetJobByIdAsync(Guid id);
        Task<IEnumerable<JobsDto>> GetAllJobsAsync();
        Task<ApiResponse> AddJobAsync(JobsDto jobDto);
        Task<ApiResponse> UpdateJobAsync(JobsDto jobDto, Guid jobId);
        Task<ApiResponse> DeleteJobAsync(Guid id);
    }
}
