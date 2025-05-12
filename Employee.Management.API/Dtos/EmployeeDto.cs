using System.ComponentModel.DataAnnotations;

namespace Employee.Management.API.Dtos;

public record class EmployeeDto(
    [Required] string DepartmentId,
    [Required][StringLength(20)] string FirstName,
    [Required][StringLength(20)] string LastName,
    [Required][Range(9, 10)] int Phone
);
