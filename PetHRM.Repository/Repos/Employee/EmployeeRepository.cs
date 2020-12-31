using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetHRM.Repositories.Data;

namespace PetHRM.Repositories.Repos.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PetHrmDbContext _context;

        public EmployeeRepository(PetHrmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Data.Model.Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
