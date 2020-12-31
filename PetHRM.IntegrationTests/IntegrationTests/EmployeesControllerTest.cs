using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PetHRM.IntegrationTests.IntegrationTests
{
    public class EmployeesControllerTest : 
        IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public EmployeesControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_EmployeeService_FindAllEmployee()
        {
            //Arrange
            var client = _factory.WithWebHostBuilder(builder => { })
                .CreateClient();
            //Act
            var url = "/api/Employees";
            var response = await client.GetAsync(url);
            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
