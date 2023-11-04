using SmartWaysTestSolution.Domain.Entities.EmployeeComponents;

namespace SmartWaysTestSolution.Persistence.Infrastructure.ParametersMethods;

public static class EmployeeParametersExtension
{
    internal static object GetUpdateParameters(this Employee existedEmployee, Employee updatedEmployee, int id) => new
    {
        Name = updatedEmployee.Name ?? existedEmployee.Name,
        Surname = updatedEmployee.Surname ?? existedEmployee.Surname,
        Phone = updatedEmployee.Phone ?? existedEmployee.Phone,
        CompanyId = updatedEmployee.CompanyId ?? existedEmployee.CompanyId,
        PassportNumber = updatedEmployee.Passport?.Number ?? existedEmployee.Passport?.Number,
        DepartmentName = updatedEmployee.Department?.Name ?? existedEmployee.Department?.Name,
        Id = id
    };

    internal static object GetAddParameters(this Employee employee) => new
    {
        Name = employee.Name,
        Surname = employee.Surname,
        Phone = employee.Phone,
        CompanyId = employee.CompanyId,
        PassportNumber = employee.Passport?.Number,
        DepartmentName = employee.Department?.Name
    };
}