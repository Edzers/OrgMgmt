using Microsoft.EntityFrameworkCore;
using OrgMgmt.Models;

namespace OrgMgmt
{
    public class OrgDbContext : DbContext
    {
        public OrgDbContext(DbContextOptions<OrgDbContext> options) : base(options) { }
        public OrgDbContext() { }
        
        public DbSet<Person> People { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<Client>().ToTable("Client");
        // }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Many-to-Many Relationship configuration
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Services)
                .WithMany(s => s.Clients);

            // One-to-Many Relationship configuration
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Services)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmployeeId);

            // Shift-Employee Many-to-Many
            modelBuilder.Entity<Shift>()
                .HasMany(s => s.Employees)
                .WithMany(e => e.Shifts);
        }
    }
}