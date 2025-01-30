using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.employee;
using API_PeopleManagement.Domain.Events;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IEmployeeService
{
    Task<EventInserted> CreateEmployee(Guid positionId, CreateEmployeesDto createEmployee);
    EmployeeDto UpdateEmployee(Guid userId, UpdateEmployeeDto employee);
    void DeleteEmployee(Guid employeeId);
    EmployeeDto GetEmployeeById(Guid userId);
    ICollection<ListEmployeeDto> GetAllEmployees();
    //double GetAverageSalary();
}