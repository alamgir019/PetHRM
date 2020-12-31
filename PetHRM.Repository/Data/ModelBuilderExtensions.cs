using System;
using Microsoft.EntityFrameworkCore;
using PetHRM.Repositories.Data.Model;

namespace PetHRM.Repositories.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
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
            );
        }
    }
}
