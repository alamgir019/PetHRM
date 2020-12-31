using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetHRM.Repositories.Data;
using PetHRM.Tests.Helpers;

namespace PetHRM.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            //builder.UseEnvironment(
            //    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<PetHrmDbContext>));

                services.Remove(descriptor);

                services.AddDbContext<PetHrmDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbTesting");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<PetHrmDbContext>();
                    db.Database.EnsureCreated();
                   
                    try
                    {
                        Utilities.ReinitializeDbForTests(db);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                } 
            });
        }
    }
}
