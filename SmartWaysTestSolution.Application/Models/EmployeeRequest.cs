﻿namespace SmartWaysTestSolution.Application.Models;

public class EmployeeRequest
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Phone { get; set; }
    public int? CompanyId { get; set; }
    public string? PassportNumber { get; set; }
    public string? DepartmentName { get; set; }
}