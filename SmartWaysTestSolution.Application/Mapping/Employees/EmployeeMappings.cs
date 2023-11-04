using SmartWaysTestSolution.Application.Models;
using SmartWaysTestSolution.Domain.Entities.EmployeeComponents;

namespace SmartWaysTestSolution.Application.Mapping.Employees;

internal static class EmployeeMappings
{
    internal static EmployeeResponse MapToResponse(this Employee employee) => new EmployeeResponse
    {
        Id = employee.Id, Name = employee.Name,
        Surname = employee.Surname, Phone = employee.Phone,
        CompanyId = employee.CompanyId, DepartmentName = employee.Department?.Name,
        PassportNumber = employee.Passport?.Number
    };

    internal static Employee MapToEmployee(this EmployeeRequest request) => new Employee
    {
        Name = request.Name, Surname = request.Surname, Phone = request.Phone,
        CompanyId = request.CompanyId, Passport = new Passport { Number = request.PassportNumber },
        Department = new Department { Name = request.DepartmentName }
    };
}