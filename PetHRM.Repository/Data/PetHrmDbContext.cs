using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetHRM.Repository.Data.Model;

namespace PetHRM.Repository.Data
{
    public class PetHrmDbContext : DbContext
    {
        public PetHrmDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
