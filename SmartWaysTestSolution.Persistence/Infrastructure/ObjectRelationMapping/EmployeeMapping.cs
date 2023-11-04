using SmartWaysTestSolution.Domain.Entities.EmployeeComponents;

namespace SmartWaysTestSolution.Persistence.Infrastructure.ObjectRelationMapping;

internal static class EmployeeMapping
{
    internal static Employee Map(Employee employee, Passport passport, Department department)
    {
        employee.Passport = passport;
        employee.Department = department;
        return employee;
    }
}