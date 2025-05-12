using System.ComponentModel.DataAnnotations;

namespace Employee.Management.API.Dtos;

public record class CreateEmployee(
    [Required] int DepartmentId,
    [Required][StringLength(20)] string FirstName,
    [Required][StringLength(20)] string LastName,
    [Required][StringLength(30)] string Email,
    [Required] int Phone
);