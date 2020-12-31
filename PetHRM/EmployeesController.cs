using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetHRM.Repositories.Data.Model;
using PetHRM.Repositories.Repos.Employee;

namespace PetHRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            var employees =  await _employeeRepository.GetEmployees();
            return employees;
        }
    }
}
