using AutoMapper;
using BLL.Mappings;
using BLL.Services.InterfacesServices;
using DAL.Data.Interfaces;
using DAL.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System.IO;
using UIL.Extensions;

namespace UIL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.ConfigureLoggerService();
            services.ConfigureRepositoryManager();
            services.AuthenticationJWT(Configuration);
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.ConfigureSwagger();
            services.AddResponseCaching();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.ConfigureSqlContext(Configuration);
            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
                config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
                {
                    Duration = 120
                });

            });
        } 

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Code API v1");
                    s.SwaggerEndpoint("/swagger/v2/swagger.json", "Code API v2");
                    s.SwaggerEndpoint("/swagger/v3/swagger.json", "Code API v3");
                });

                app.ConfigureExceptionHandler(logger);

                app.UseHttpsRedirection();

                app.UseResponseCaching();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
    }
}
