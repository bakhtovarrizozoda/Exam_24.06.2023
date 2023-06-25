using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Salary> Salaries { get; set; }
    public DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }
    public DbSet<DepartmentManager> DepartmentManagers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentEmployee>().HasKey(p => new { p.DepartmentId, p.EmployeeId });
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DepartmentManager>().HasKey(p => new { p.DepartmentId, p.EmployeeId });
        base.OnModelCreating(modelBuilder);
    }
}