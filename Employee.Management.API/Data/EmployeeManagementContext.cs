using System;
using Employee.Management.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Management.API.Data;

public class EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options) : DbContext(options)
{

    public DbSet<Employe> Employees => Set<Employe>();
    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
            new { Id = 1, Name = "Software Engineer" },
            new { Id = 2, Name = "Data Scientist" },
            new { Id = 3, Name = "Web Developer" },
            new { Id = 4, Name = "Designer" }
        );
    }
}
