using Hackathon.AgriFood.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Hackathon.AgriFood.Models.Converters;
using Hackathon.AgriFood.Models.Converters.Interfaces;
using Hackathon.AgriFood.Repositories.Providers;
using Hackathon.AgriFood.Services.Interfaces;
using Hackathon.AgriFood.Services.Services;
using Microsoft.OpenApi.Models;
using System;
using Hackathon.AgriFood.Repositories.Interfaces;
using Hackathon.AgriFood.Repositories.Repositories;
using Hackathon.AgriFood.Models.Models;

namespace Hackathon.AgriFood.WebApi
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
            services.AddDbContext<AgriFoodDbContext>(options =>
                options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IEntityConverter, EntityConverter>();
            services.AddTransient<IRepositoryProvider, RepositoryProvider>();

            services.AddTransient<IRepository<Customer>, CustomerRepository>();
            services.AddTransient<IRepository<Localization>, LocalizationRepository>();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ILocalizationService, LocalizationService>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hackathon.AgriFood API",
                    Description = "Hackathon.AgriFood API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT license",
                        Url = new Uri("https://www.mit.edu/~amini/LICENSE.md"),
                    }
                });
                var security = new OpenApiSecurityRequirement();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(security);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShareEventAPI v1.0");
            });

            // CORS
            app.UseCors(config => config
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}