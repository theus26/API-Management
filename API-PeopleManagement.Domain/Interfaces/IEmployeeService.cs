using API_PeopleManagement.Domain.DTO;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IEmployeeService
{
    EmployeeDto CreateEmployee(CreateEmployeesDto createEmployee);
    EmployeeDto UpdateEmployee(Guid employeeId, UpdateEmployeeDto employee);
    void DeleteEmployee(Guid employeeId);
    EmployeeDto GetEmployeeById(Guid userId);
    ICollection<EmployeeDto> GetAllEmployees();
    double GetAverageSalary();
}