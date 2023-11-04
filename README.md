# SmartWaysTestSolution
localhost:8080/swagger - Swagger UI

localhost:5050 - pgadmin4

# Запросы
<b>Добавление сотрудника</b>: [<b>HTTP POST</b>] /Employee, RequestBody: EmployeeRequest,

<b>Получение сотрудников по компании</b>: [<b>HTTP GET</b>] /Employee/company/{companyId},

<b>Получение сотрудников по отделу</b>: [<b>HTTP GET</b>] /Employee/department/{departmentId},

<b>Удаление сотрудника:</b> [<b>HTTP DELETE</b>] /Employee/{id},

<b>Изменение части (или всех кроме Id) полей сотрудника</b>: [<b>HTTP PATCH</b>] /Employee/{id}, RequestBody: EmployeeRequest;

## EmployeeRequest

```json
{
  "name": "string",
  "surname": "string",
  "phone": "string",
  "companyId": 0,
  "passportNumber": "string",
  "departmentName": "string"
}
```

## EmployeeResponse
```json
{
  "id" : 0,
  "name": "string",
  "surname": "string",
  "phone": "string",
  "companyId": 0,
  "passportNumber": "string",
  "departmentName": "string"
}
```


# Тестовые таблицы (PostgreSQL):
## Passports
| Number       |     Type      | 
| -------------| ------------- |
| '4445-2535'  | 'Default'     |
| '4456-2532'  | 'Default'     |
| '5567-4551'  | 'Default'     |
| '5864-5165'  | 'Default'     |
| '7775-1567'  | 'Default'     |
## Departments
| Name       |     Phone      | 
| -------------| ------------- |
| 'Отдел Приколов'  | '+7-777-777-77-77'     |
| 'Отдел Анекдотов'  | '+7-999-999-99-99'     |
| 'Отдел Мексиканцев'  | '+7-000-000-00-00'     |
## Employees
| Id       |     Name      | Surname | Phone | CompanyId | PassportNumber | DepartmentName |
| -------------| ------------- | -------------| ------------- |-|-|-|
| 1  | 'Максим'     | 'Максимов' | '+1-111-111-11-11' | 0 | '4445-2535' | 'Отдел Приколов' |
| 2  | 'Александр'     | 'Александров' | '+2-222-222-22-22' | 0 | '4456-2532' | 'Отдел Приколов' |
| 3  | 'Пётр'     | 'Петров' | '+3-333-333-33-33' | 1 | '5567-4551' | 'Отдел Анекдотов' |
| 4  | 'Аксён'     | 'Аксёнов' | '+4-444-444-44-44' | 1 | '5864-5165' | 'Отдел Анекдотов' |
| 5  | 'А'     | 'Б' | '++5-555-555-55-55' | 2 | '7775-1567' | 'Отдел Мексиканцев' |
