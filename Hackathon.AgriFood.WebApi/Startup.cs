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

            services.AddTransient<ICustomerService, CustomerService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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