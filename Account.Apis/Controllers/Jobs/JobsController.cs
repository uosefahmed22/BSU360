using Account.Core.Dtos.Jobs;
using Account.Core.Services.Jobs;
using Account.Reposatory.Reposatories.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers.Jobs
{
    public class JobsController : ApiBaseController
    {
        private readonly IJobsReposaitory _jobsReposaitory;

        public JobsController(IJobsReposaitory jobsReposaitory)
        {
           _jobsReposaitory = jobsReposaitory;
        }

        [HttpPost("AddJob")]
        public async Task<IActionResult> AddJob([FromBody] JobsDto jobDto)
        {
            var apiResponse = await _jobsReposaitory.AddJobAsync(jobDto);

            if (apiResponse.StatusCode == 200)
            {
                return Ok(apiResponse);
            }
            else
            {
                return StatusCode(apiResponse.StatusCode, apiResponse);
            }
        }

        [HttpPut("UpdateJob/{id}")]
        public async Task<IActionResult> UpdateJob(Guid id, [FromBody] JobsDto jobDto)
        {
            if (id != jobDto.Id)
            {
                return BadRequest("Job ID in the request body does not match the ID in the URL.");
            }

            var response = await _jobsReposaitory.UpdateJobAsync(jobDto, id);

            if (response.StatusCode == 200)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response); 
            }
        }


        [HttpGet("jobs/{id}")]
        public async Task<IActionResult> GetJobById(Guid id)
        {
            var jobDto = await _jobsReposaitory.GetJobByIdAsync(id);

            if (jobDto == null)
            {
                return NotFound();
            }

            return Ok(jobDto);
        }

        [HttpGet("GetAllJobs")]
        public async Task<ActionResult<IEnumerable<JobsDto>>> GetAllJobs()
        {
            var jobs = await _jobsReposaitory.GetAllJobsAsync();
            if (jobs == null || !jobs.Any())
            {
                return NotFound();
            }
            return Ok(jobs);
        }

        [HttpDelete("DeleteJob/{id}")]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            var apiResponse = await _jobsReposaitory.DeleteJobAsync(id);

            if (apiResponse.StatusCode == 200)
            {
                return Ok(apiResponse);
            }
            else if (apiResponse.StatusCode == 400)
            {
                return BadRequest(apiResponse);
            }
            else
            {
                return StatusCode(apiResponse.StatusCode, apiResponse); // Return error response
            }
        }


    }
}
