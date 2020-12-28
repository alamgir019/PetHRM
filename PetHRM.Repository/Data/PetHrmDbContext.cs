using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetHRM.Repository.Data.Model;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace PetHRM.Repository.Data
{
    public class PetHrmDbContext : DbContext
    {
        public PetHrmDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Employee>()
                .HasIndex(x => x.EmployeeId).IsUnique();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=localhost;port=3306;database=pet_hrm_db;user=root;password=;"
        //        , new MySqlServerVersion(new Version(10, 1, 40)), mySqlOptions => mySqlOptions
        //            .CharSetBehavior(CharSetBehavior.NeverAppend));
        //}
    }
}
