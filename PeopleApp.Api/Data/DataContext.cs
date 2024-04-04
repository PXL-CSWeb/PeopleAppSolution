using Microsoft.EntityFrameworkCore;
using PeopleApp.ClassLib.Models;
using System.Reflection.Metadata;

namespace PeopleApp.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.People)
                .WithOne(p => p.Department)
                .HasForeignKey(p => p.DepartmentId)
                .HasPrincipalKey(d => d.Id);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.People)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId)
                .HasPrincipalKey(l => l.Id);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
