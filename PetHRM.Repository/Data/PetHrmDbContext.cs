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
    }
}
