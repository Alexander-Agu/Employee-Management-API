using System;

namespace Employee.Management.API.Entities;

public class Employe
{
    public int Id { get; set; }
    public required int DepartmentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required int Phone { get; set; }
}
