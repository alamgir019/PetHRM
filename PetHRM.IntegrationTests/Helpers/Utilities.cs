using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetHRM.Repositories.Data;
using PetHRM.Repositories.Data.Model;

namespace PetHRM.Tests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(PetHrmDbContext db)
        {
            db.Employees.AddRange(GetSeedingEmployees());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(PetHrmDbContext db)
        {
            db.RemoveRange(db.Employees);
            InitializeDbForTests(db);
        }

        private static List<Employee> GetSeedingEmployees()
        {

            return new List<Employee>
            {
                new Employee
                {
                    Id = "1",
                    EmployeeId = "e001",
                    Designation = "Manger",
                    FirstName = "Darren",
                    LastName = "Sammy",
                    Address = "Dhaka",
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now
                }
            };
        }
    }
}
