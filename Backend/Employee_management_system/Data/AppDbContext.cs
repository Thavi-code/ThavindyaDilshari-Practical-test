using Microsoft.EntityFrameworkCore;
using Employee_management_system.Models;

namespace Employee_management_system.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
         .HasMany(e => e.Departments)
         .WithMany(d => d.Employees)
         .UsingEntity<EmployeeDepartment>(
             j => j
                 .HasOne(ed => ed.Department)
                 .WithMany()
                 .HasForeignKey(ed => ed.DepartmentNo),
             j => j
                 .HasOne(ed => ed.Employee)
                 .WithMany()
                 .HasForeignKey(ed => ed.EmployeeNo),
             j =>
             {
                 j.ToTable("EmployeeDepartments");
                 j.HasKey(ed => new { ed.EmployeeNo, ed.DepartmentNo });
             }
         );

            //  seed data for testing
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Alice",
                    LastName = "Smith",
                    Department = "Sales",
                    Address = "123 Colombo",
                    MobileNumber = "0711234567",
                    Email = "alice@gmail.com",
                    Birthday = new DateTime(1990, 1, 1),
                    CreationDate = DateTime.Now
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Kamal",
                    LastName = "Jones",
                    Department = "Marketing",
                    Address = "456 Colombo",
                    MobileNumber = "0771234567",
                    Email = "kamal@gmail.com",
                    Birthday = new DateTime(1991, 2, 2),
                    CreationDate = DateTime.Now
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Amal",
                    LastName = "Perera",
                    Department = "IT",
                    Address = "789 Colombo",
                    MobileNumber = "0751237896",
                    Email = "amal@gmail.com",
                    Birthday = new DateTime(1992, 3, 3),
                    CreationDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "Sales"
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Marketing"
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "IT"
                }
            );

            //  seed data for the join table
            modelBuilder.Entity<EmployeeDepartment>().HasData(
         new EmployeeDepartment { EmployeeNo = 1, DepartmentNo = 1 },
         new EmployeeDepartment { EmployeeNo = 2, DepartmentNo = 2 },
         new EmployeeDepartment { EmployeeNo = 3, DepartmentNo = 3 }
     );
        }
    }
}
