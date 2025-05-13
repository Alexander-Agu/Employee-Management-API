using System;
using System.Text.RegularExpressions;
using Employee.Management.API.Data;
using Employee.Management.API.Dtos;
using Employee.Management.API.Entities;
using Employee.Management.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Employee.Management.API.Endpoints;

public static class EmployeeEndpoints
{
    public static RouteGroupBuilder MapEmployeeEnpoints(this WebApplication app)
    {
        var group = app.MapGroup("employees").WithParameterValidation();
        string GetEmployeeEndpoint = "GetEmployee";

        // GET - gets all employees
        group.MapGet("/", async (EmployeeManagementContext dbContext) => await dbContext.Employees.ToListAsync());


        // GET - gets employees by DepartmentId
        group.MapGet("/department/{departId}", async (int departId, EmployeeManagementContext dbContext) =>
        {
            List<Employe> employees = await dbContext.Employees.Where(x => x.DepartmentId == departId).ToListAsync();

            return employees is null || employees.Count == 0 ? Results.NotFound() : Results.Ok(employees);
        });


        // GET - gets employees by ID
        group.MapGet("/{id}", async (int id, EmployeeManagementContext dbContext) =>
        {

            Employe? employee = await dbContext.Employees.FindAsync(id);

            return employee is null ? Results.NotFound() : Results.Ok(employee.ToDto(dbContext.Departments.Find(employee.DepartmentId).Name));
        })
        .WithName(GetEmployeeEndpoint);


        // POST - creates an imployee
        group.MapPost("/", async (CreateEmployee newEmployee, EmployeeManagementContext dbContext) =>
        {
            Employe employee = newEmployee.ToEntity();
            Department? department = await dbContext.Departments.FindAsync(employee.DepartmentId);

            // If the users department is not found
            if (department.Name is null) return Results.NotFound();

            await dbContext.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetEmployeeEndpoint, new { id = employee.Id }, employee.ToDto(department.Name));
        })
        .WithParameterValidation();


        // PUT - updates employee information by ID
        group.MapPut("/{id}", async (int id, UpdateEmployee updateEmployee, EmployeeManagementContext dbContext) =>
        {
            Employe? employee = await dbContext.Employees.FindAsync(id);

            if (employee is null) return Results.NotFound();

            if (updateEmployee.FirstName != "")
            {
                employee.FirstName = updateEmployee.FirstName;
            }
            if (updateEmployee.LastName != "")
            {
                employee.LastName = updateEmployee.LastName;
            }
            if (updateEmployee.Email != "")
            {
                employee.Email = updateEmployee.Email;
            }
            if (updateEmployee.Phone != employee.Phone)
            {
                employee.Phone = updateEmployee.Phone;
            }
            if (updateEmployee.DepartmentId != employee.DepartmentId)
            {
                employee.DepartmentId = updateEmployee.DepartmentId;
            }

            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetEmployeeEndpoint, new { id = employee.Id }, employee.ToDto(dbContext.Departments.Find(employee.DepartmentId).Name));
        });



        // DELETE - delete employee by ID
        group.MapDelete("/{id}", async (int id, EmployeeManagementContext dbContext) =>
        {
            await dbContext.Employees.Where(x => x.Id == id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}
