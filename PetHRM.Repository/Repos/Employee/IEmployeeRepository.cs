using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHRM.Repositories.Repos.Employee
{
    public interface IEmployeeRepository
    {
        Task<List<Data.Model.Employee>> GetEmployees();
    }
}
