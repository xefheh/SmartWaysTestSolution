using SmartWaysTestSolution.Domain.Entities.EmployeeComponents;

namespace SmartWaysTestSolution.Persistence.Repositories.Abstraction;

public interface IEmployeeRepository
{
    /// <summary>
    /// Добавление сотрудника в базу данных.
    /// </summary>
    /// <param name="employee">Объект сотрудника.</param>
    /// <returns>Id добавленного сотрудника</returns>
    Task<int> AddAsync(Employee employee);
    
    /// <summary>
    /// Получение сотрудников по имени отдела из базы данных.
    /// </summary>
    /// <param name="departmentName">Имя отдела.</param>
    /// <returns>Перечисление сотрудников</returns>
    Task<IEnumerable<Employee>> GetByDepartmentNameAsync(string departmentName);
    
    /// <summary>
    /// Получение сотрудников по номеру компании из базы данных.
    /// </summary>
    /// <param name="companyId">Id компании.</param>
    /// <returns>Перечисление сотрудников</returns>
    Task<IEnumerable<Employee>> GetByCompanyIdAsync(int companyId);
    
    /// <summary>
    /// Обновление сотрудника из базы данных.
    /// </summary>
    /// <param name="id">Id сотрудника.</param>
    /// <param name="employee">Объект сотрудника.</param>
    /// <returns>Id обновлённого сотрудника</returns>
    Task<int> UpdateAsync(int id, Employee employee);
    
    /// <summary>
    /// Удаление сотрудника из базы данных.
    /// </summary>
    /// <param name="id">Id сотрудника.</param>
    /// <returns>0 - сотрудник не удален, 1 - сотрудник удален.</returns>
    Task<int> DeleteAsync(int id);
}