using System.Data;
using Dapper;
using Npgsql;
using SmartWaysTestSolution.Domain.Entities.EmployeeComponents;
using SmartWaysTestSolution.Persistence.Infrastructure.Exceptions;
using SmartWaysTestSolution.Persistence.Infrastructure.ObjectRelationMapping;
using SmartWaysTestSolution.Persistence.Infrastructure.ParametersMethods;
using SmartWaysTestSolution.Persistence.Queries.Employees;
using SmartWaysTestSolution.Persistence.Repositories.Abstraction;

namespace SmartWaysTestSolution.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly string _connectionString;

    public EmployeeRepository(string connectionString) => _connectionString = connectionString;
    
    public async Task<int> AddAsync(Employee employee)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        var id = await dbConnection.QuerySingleAsync<int>(EmployeeQueries.InsertQuery, param: employee.GetAddParameters());
        return id;
    }

    public async Task<IEnumerable<Employee>> GetByDepartmentNameAsync(string departmentName)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        var employees = await dbConnection.QueryAsync<Employee, Passport, Department, Employee>
        (EmployeeQueries.SelectByDepartmentNameQuery, map: EmployeeMapping.Map, param: new { DepartmentName = departmentName },
            splitOn: "Number, Name");
        return employees;
    }

    public async Task<IEnumerable<Employee>> GetByCompanyIdAsync(int companyId)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        var employees = await dbConnection.QueryAsync<Employee, Passport, Department, Employee>
        (EmployeeQueries.SelectByCompanyIdQuery, map: EmployeeMapping.Map, param: new { CompanyId = companyId },
            splitOn: "Number, Name");
        return employees;
    }

    public async Task<int> UpdateAsync(int id, Employee employee)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        var existedEmployees = await dbConnection.QueryAsync<Employee, Passport, Department, Employee>(
            EmployeeQueries.GetEmployeeByIdQuery, map: EmployeeMapping.Map, param: new { Id = id }, splitOn: "Number, Name");
        if (!existedEmployees.Any()) throw new NotFoundException(typeof(Employee), id);
        var existedEmployee = existedEmployees.First();
        await dbConnection.ExecuteAsync(EmployeeQueries.UpdateQuery, existedEmployee.GetUpdateParameters(employee, id));
        return id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        return await dbConnection.ExecuteAsync(EmployeeQueries.DeleteByIdQuery, new { Id = id });
    }
}