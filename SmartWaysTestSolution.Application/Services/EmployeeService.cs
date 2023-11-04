using SmartWaysTestSolution.Application.Interfaces;
using SmartWaysTestSolution.Application.Mapping.Employees;
using SmartWaysTestSolution.Application.Models;
using SmartWaysTestSolution.Persistence.Repositories.Abstraction;

namespace SmartWaysTestSolution.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository) => _repository = repository;

    public async Task<int> AddAsync(EmployeeRequest request)
    {
        var employee = request.MapToEmployee();
        var id = await _repository.AddAsync(employee);
        return id;
    }

    public async Task<IEnumerable<EmployeeResponse>> GetByCompanyIdAsync(int companyId)
    {
        var employees = await _repository.GetByCompanyIdAsync(companyId);
        var employeesResponse = employees.Select(employee => employee.MapToResponse());
        return employeesResponse;
    }
    
    public async Task<IEnumerable<EmployeeResponse>> GetByDepartmentNameAsync(string departmentName)
    {
        var employees = await _repository.GetByDepartmentNameAsync(departmentName);
        var employeesResponse = employees.Select(employee => employee.MapToResponse());
        return employeesResponse;
    }

    public async Task<int> UpdateAsync(int id, EmployeeRequest request)
    {
        var employee = request.MapToEmployee();
        return await _repository.UpdateAsync(id, employee);
    }

    public async Task<int> DeleteAsync(int id) => await _repository.DeleteAsync(id);
}