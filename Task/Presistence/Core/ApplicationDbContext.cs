using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task.Domain.ApplicationUser;
using Task.Domain.Employees;

namespace Task.Presistence.Core
{
    public class ApplicationDbContext:IdentityDbContext
    {
        private readonly DbContextOptions<ApplicationDbContext> options;

        public DbSet<Employee> Employees { set; get; }
        public DbSet<ApplicationUser> ApplicationUsers { set; get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            this.options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}