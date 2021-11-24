using System;
using System.Threading.Tasks;
using InnovativeSoftware.Infrastructure;
using InnovativeSoftware.Repositories;
using InnovativeSoftware.Repositories.Clients;
using InnovativeSoftware.Repositories.Interfaces;
using InnovativeSoftware.Services;
using InnovativeSoftware.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace InnovativeSoftware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // allow all cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    // Any origin is allowed
                    builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed((host) => true).AllowCredentials();
                });
            });
            
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InnovativeSoftware", Version = "v1" });
            });

            services.AddDbContext<PowerUnitContext>();

            services.AddHttpClient<ElspotClient>();

            services.AddTransient<IElectricityPriceService, ElectricityPriceService>();

            services.AddTransient<ICo2EmissionService, Co2EmissionService>();
            services.AddTransient<ICo2EmissionRepository, Co2EmissionRepository>();
            services.AddHttpClient<Co2EmissionPrognosisClient>();

            services.AddTransient<IPowerUnitService, PowerUnitService>();
            services.AddTransient<IPowerUnitRepository, PowerUnitRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InnovativeSoftware v1"));
            }

            await UpdateDatabase(app, logger);
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }


        // Credits: https://github.com/jakobhviid/Dashboard-Interface-Docker/blob/master/SocketServer/Startup.cs
        // Ensures an updated database to the latest migration
        private async Task UpdateDatabase(IApplicationBuilder app, ILogger<Startup> logger)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<PowerUnitContext>())
                {
                    // Npgsql resiliency strategy does not work with Database.EnsureCreated() and Database.Migrate().
                    // Therefore a retry pattern is implemented for this purpose 
                    // if database connection is not ready it will retry 3 times before finally quiting
                    var retryCount = 3;
                    var currentRetry = 0;
                    while (true)
                    {
                        try
                        {
                            logger.LogInformation("Attempting database migration");

                            context.Database.Migrate();

                            logger.LogInformation("Database migration & connection successful");

                            break; // just break if migration is successful
                        }
                        catch (SqliteException)
                        {
                            logger.LogError("Database migration failed. Retrying in 5 seconds ...");

                            currentRetry++;

                            if (
                                currentRetry ==
                                retryCount) // Here it is possible to check the type of exception if needed with an OR. And exit if it's a specific exception.
                            {
                                // We have tried as many times as retryCount specifies. Now we throw it and exit the application
                                logger.LogCritical($"Database migration failed after {retryCount} retries");
                                throw;
                            }
                        }

                        // Waiting 5 seconds before trying again
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                }
            }
        }
    }
}