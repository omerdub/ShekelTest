using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShekelAPI.DAL.Data;
using ShekelAPI.DAL.Repositories;
using ShekelAPI.Entities.DTOs;
using ShekelAPI.Validators;

namespace ShekelAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShekelDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IShekelDbContext, ShekelDbContext>();
            services.AddTransient<IShekelRepository, ShekelRepository>();
            services.AddTransient<INewCustomerValidator<NewCustomerDto>, NewCustomerValidator>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IShekelDbContext ctx)
        {
            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "api/{controller}/{action}");
            });
        }
    }
}
