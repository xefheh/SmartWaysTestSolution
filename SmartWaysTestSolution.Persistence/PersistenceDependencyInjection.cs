using Microsoft.Extensions.DependencyInjection;
using SmartWaysTestSolution.Persistence.Repositories;
using SmartWaysTestSolution.Persistence.Repositories.Abstraction;

namespace SmartWaysTestSolution.Persistence;

public static class PersistenceDependencyInjection
{
    public static void AddRepositories(this IServiceCollection services, string connectionString) =>
        services.AddSingleton<IEmployeeRepository, EmployeeRepository>(sp => new EmployeeRepository(connectionString));
}