using Microsoft.AspNetCore.Mvc;
using SmartWaysTestSolution.Application.Interfaces;
using SmartWaysTestSolution.Application.Models;

namespace SmartWaysTestSolution.API.Controllers;


[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service) => _service = service;

    [HttpPost]
    public async Task<ActionResult<int>> AddAsync([FromBody] EmployeeRequest employeeRequest)
    {
        var id = await _service.AddAsync(employeeRequest);
        return Ok(id);
    }

    [HttpGet("company/{companyId:int}")]
    public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetAsync(int companyId)
    {
        var employees = await _service.GetByCompanyIdAsync(companyId);
        return Ok(employees);
    }
    
    [HttpGet("department/{departmentName}")]
    public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetAsync(string departmentName)
    {
        var employees = await _service.GetByDepartmentNameAsync(departmentName);
        return Ok(employees);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeleteAsync(int id)
    {
        var deletedId = await _service.DeleteAsync(id);
        return Ok(deletedId);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<int>> UpdateAsync(int id, [FromBody] EmployeeRequest request)
    {
        var updatedId = await _service.UpdateAsync(id, request);
        return Ok(updatedId);
    }
}