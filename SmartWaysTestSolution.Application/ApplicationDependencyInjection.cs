using Microsoft.Extensions.DependencyInjection;
using SmartWaysTestSolution.Application.Interfaces;
using SmartWaysTestSolution.Application.Services;

namespace SmartWaysTestSolution.Application;

public static class ApplicationDependencyInjection
{
    public static void AddApplication(this IServiceCollection services) =>
        services.AddSingleton<IEmployeeService, EmployeeService>();
}