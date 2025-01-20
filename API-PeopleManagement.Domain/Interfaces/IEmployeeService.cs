using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.Events;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeInsertedEvent> CreateEmployee(CreateEmployeesDto createEmployee);
    EmployeeDto UpdateEmployee(Guid employeeId, UpdateEmployeeDto employee);
    void DeleteEmployee(Guid employeeId);
    EmployeeDto GetEmployeeById(Guid userId);
    ICollection<EmployeeDto> GetAllEmployees();
    double GetAverageSalary();
}