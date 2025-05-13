using System;
using Employee.Management.API.Dtos;
using Employee.Management.API.Entities;

namespace Employee.Management.API.Mapping;

public static class EmployeeMapping
{
    public static Employe ToEntity(this CreateEmployee employee, Department Department)
    {
        return new()
        {
            DepartmentId = employee.DepartmentId,
            Department = Department,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Phone = employee.Phone
        };
    }

    public static Employe ToUpdateEntity(this UpdateEmployee employee, Department Department)
    {
        return new()
        {
            DepartmentId = employee.DepartmentId,
            Department = Department,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Phone = employee.Phone
        };
    }

    public static EmployeeDto ToDto(this Employe employee, string Name)
    {
        return new(
            Name,
            employee.FirstName,
            employee.LastName,
            employee.Phone
        );
    }
}
