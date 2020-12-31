using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetHRM.Repositories.Data;
using PetHRM.Repositories.Repos.Employee;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace PetHRM
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("petHrmDB");
            services.AddDbContext<PetHrmDbContext>(options =>
                    options.UseMySql(connectionString,new MySqlServerVersion(new Version(10, 1, 40)), mySqlOptions => mySqlOptions
                        .CharSetBehavior(CharSetBehavior.NeverAppend)));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet HRM V1");
            });
            app.UseHttpsRedirection();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }
    }
}
