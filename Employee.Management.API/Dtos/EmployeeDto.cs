using System.ComponentModel.DataAnnotations;

namespace Employee.Management.API.Dtos;

public record class EmployeeDto(
    [Required] string Department,
    [Required][StringLength(20)] string FirstName,
    [Required][StringLength(20)] string LastName,
    [Required] int Phone
);
