using SmartWaysTestSolution.Application.Models;

namespace SmartWaysTestSolution.Application.Interfaces;

public interface IEmployeeService
{
    /// <summary>
    /// Добавление нового сотрудника.
    /// </summary>
    /// <param name="request">Запрос с полями для создания сотрудника.</param>
    /// <returns>Id созданного сотрудника</returns>
    Task<int> AddAsync(EmployeeRequest request);
    
    /// <summary>
    /// Получение сотрудников по Id компании.
    /// </summary>
    /// <param name="companyId">Id компании.</param>
    /// <returns>Перечисление сотрудников.</returns>
    Task<IEnumerable<EmployeeResponse>> GetByCompanyIdAsync(int companyId);
    
    /// <summary>
    /// Получение сотрудников по названию отдела.
    /// </summary>
    /// <param name="departmentName">Название отдела.</param>
    /// <returns>Перечисление сотрудников.</returns>
    Task<IEnumerable<EmployeeResponse>> GetByDepartmentNameAsync(string departmentName);
    
    /// <summary>
    /// Обновление сотрудника по Id.
    /// </summary>
    /// <param name="id">Id обновляемого сотрудника.</param>
    /// <param name="request">Значение полей для обновления</param>
    /// <returns>Id обновлённого сотрудника</returns>
    Task<int> UpdateAsync(int id, EmployeeRequest request);
    
    /// <summary>
    /// Удаление сотрудника по Id.
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    /// <returns>0 - сотрудник не удален, 1 - сотрудник удален</returns>
    Task<int> DeleteAsync(int id);
}