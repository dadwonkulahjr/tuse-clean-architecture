using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyGentelellaCleanArchitecture.Domain.Enities;
using MyGentelellaCleanArchitecture.Infrastructure.Persistence.Configurations;
using System.Reflection;

namespace MyGentelellaCleanArchitecture.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
            builder.SeedDatabaseWithInitialData();
                   
        }
    }
}
