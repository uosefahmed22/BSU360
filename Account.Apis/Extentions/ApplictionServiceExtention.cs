using Account.Apis.Errors;
using Account.Core.Services.Business;
using Account.Reposatory.Data.Business;
using Account.Reposatory.Data.Identity;
using Account.Reposatory.Reposatories.Buisness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Account.Apis.Extentions
{
    public static class ApplictionServiceExtention
    {
        public static IServiceCollection AddAplictionService(this IServiceCollection service, IConfiguration configuration)
        {
            // Configure API behavior options

            service.Configure<ApiBehaviorOptions>(Options =>
            {
                // Customize the behavior for handling invalid model state
                Options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    // Extract validation errors from the ModelState
                    var Errors = actionContext.ModelState
                        .Where(P => P.Value.Errors.Count() > 0)
                        .SelectMany(P => P.Value.Errors)
                        .Select(E => E.ErrorMessage)
                        .ToArray();

                    // Create a response object with validation errors
                    var ValidationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = Errors
                    };

                    // Return a BadRequestObjectResult with the validation error response
                    return new BadRequestObjectResult(ValidationErrorResponse);
                };
            });

            service.AddDbContext<BusinessDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("BusinessConnections"));
            });

            // Register a scoped service for payment services

            service.AddScoped<IBusnissRepository, BusnissRepository>();
            


            //Add here anny otehrt injection related to program....
            return service;
        }
    }
}
