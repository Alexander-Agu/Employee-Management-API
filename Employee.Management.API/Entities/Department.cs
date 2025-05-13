using System;

namespace Employee.Management.API.Entities;

public class Department
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<Employe> Employes { get; set; } = new();
}
