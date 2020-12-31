using Microsoft.EntityFrameworkCore;
using PetHRM.Repositories.Data.Model;

namespace PetHRM.Repositories.Data
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
            modelBuilder.Seed();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=localhost;port=3306;database=pet_hrm_db;user=root;password=;"
        //        , new MySqlServerVersion(new Version(10, 1, 40)), mySqlOptions => mySqlOptions
        //            .CharSetBehavior(CharSetBehavior.NeverAppend));
        //}
    }
}
