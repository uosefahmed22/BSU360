using Account.Apis.Errors;
using Account.Apis.Extentions;
using Account.Core.Models.Account;
using Account.Core.Models.Account.Identity;
using Account.Reposatory.Data.Business;
using Account.Reposatory.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Account.Apis
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region configure service

            builder.Services.AddControllers().Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));

            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddSwaggerService();
            builder.Services.AddAplictionService(builder.Configuration);
            builder.Services.AddMemoryCache();


            #endregion
            var app = builder.Build();

            #region Update automatically
            // Create a service scope to resolve services
            using var scope = app.Services.CreateScope();
            var Services = scope.ServiceProvider;

            // Obtain logger factory to create loggers
            var loggerfactory = Services.GetRequiredService<ILoggerFactory>();
            try
            {
                // Get the database context for Identity
                // Apply database migration asynchronously
                // Get the UserManager service to manage users
                // Seed initial user data for the Identity context
                //await AppIdentityDbContextSeed.SeedUserAsync(usermanager);

                var identityDbContext = Services.GetRequiredService<AppIdentityDbContext>();
                await identityDbContext.Database.MigrateAsync();

                var usermanager = Services.GetRequiredService<UserManager<AppUser>>();

                var BusinessDbContext = Services.GetRequiredService<BusinessDbContext>();
                await BusinessDbContext.Database.MigrateAsync();


            }
            catch (Exception ex)
            {
                // If an exception occurs during migration or seeding, log the error
                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Occurred During Applying The Migrations");
            }
            #endregion


            #region configure middlewares
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseMiddleware<ExeptionMiddleWares>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddlewares();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            #endregion
            app.Run();
        }
    }
}
