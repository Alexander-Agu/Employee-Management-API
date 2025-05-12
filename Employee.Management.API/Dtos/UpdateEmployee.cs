using System.ComponentModel.DataAnnotations;

namespace Employee.Management.API.Dtos;

public record class UpdateEmployee(
    int DepartmentId,
    [StringLength(20)] string FirstName,
    [StringLength(20)] string LastName,
    [StringLength(30)] string Email,
    int Phone
);
