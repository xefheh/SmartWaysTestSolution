namespace SmartWaysTestSolution.Persistence.Queries.Employees;

internal static class EmployeeQueries
{
    internal static string InsertQuery => "insert into employees " +
                                          "(\"Name\", \"Surname\", \"Phone\", \"CompanyId\", \"PassportNumber\", \"DepartmentName\") " +
                                          "values " +
                                          "(@Name, @Surname, @Phone, @CompanyId, @PassportNumber, @DepartmentName) " +
                                          "returning \"Id\"";

    internal static string SelectByCompanyIdQuery => "select e.\"Id\", " +
                                                     "e.\"Name\", " +
                                                     "e.\"Surname\", " +
                                                     "e.\"Phone\", " +
                                                     "e.\"CompanyId\", " +
                                                     "p.\"Number\", " +
                                                     "p.\"Type\", " +
                                                     "d.\"Name\", " +
                                                     "d.\"Phone\" " +
                                                     "from employees e " +
                                                     "left join passports p on p.\"Number\" = e.\"PassportNumber\" " +
                                                     "left join departments d on d.\"Name\" = e.\"DepartmentName\" " +
                                                     "where e.\"CompanyId\" = @CompanyId;";
    
    internal static string SelectByDepartmentNameQuery => "select e.\"Id\", " +
                                                          "e.\"Name\", " +
                                                          "e.\"Surname\", " +
                                                          "e.\"Phone\", " +
                                                          "e.\"CompanyId\", " +
                                                          "p.\"Number\", " +
                                                          "p.\"Type\", " +
                                                          "d.\"Name\", " +
                                                          "d.\"Phone\" " +
                                                          "from employees e " +
                                                          "left join passports p on p.\"Number\" = e.\"PassportNumber\" " +
                                                          "left join departments d on d.\"Name\" = e.\"DepartmentName\" " +
                                                          "where d.\"Name\" = @DepartmentName;";

    internal static string DeleteByIdQuery => "delete from employees " +
                                              "where \"Id\"=@Id;";

    internal static string GetEmployeeByIdQuery => "select e.\"Name\", " +
                                                   "e.\"Surname\", " +
                                                   "e.\"Phone\", " +
                                                   "e.\"CompanyId\", " +
                                                   "p.\"Number\", " +
                                                   "p.\"Type\", " +
                                                   "d.\"Name\", " +
                                                   "d.\"Phone\" " +
                                                   "from employees e " +
                                                   "left join passports p on p.\"Number\" = e.\"PassportNumber\" " +
                                                   "left join departments d on d.\"Name\" = e.\"DepartmentName\" " +
                                                   "where \"Id\" = @Id;";

    internal static string UpdateQuery => "update employees " +
                                          "set \"Name\" = @Name, " +
                                          "\"Surname\" = @Surname, " +
                                          "\"Phone\" = @Phone, " +
                                          "\"CompanyId\" = @CompanyId, " +
                                          "\"PassportNumber\" = @PassportNumber, " +
                                          "\"DepartmentName\" = @DepartmentName " +
                                          "where \"Id\" = @Id;";
}