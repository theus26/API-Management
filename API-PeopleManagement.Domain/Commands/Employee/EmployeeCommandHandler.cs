using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Domain.Commands.Employee;

public class EmployeeCommandHandler (IBaseRepository<Employees> employeeRepository, IUnitOfWork unitOfWork, IMapper mapper) 
{
    public async Task<EventInserted> HandleCommand(InsertEmployeeCommand insertEmployeeCommand)
    {
        var employeeMapper = mapper.Map<Employees>(insertEmployeeCommand);
        var employee = employeeRepository.Create(employeeMapper);
        return await unitOfWork.Commit() ? new EventInserted(employee.Id, true) 
            : new EventInserted(employee.Id, false);
    }
    
    public void HandleCommand(DeleteEmployeeCommand deleteEmployeeCommand)
    {
        var employee = employeeRepository.Get(deleteEmployeeCommand.Id);
        if (employee == null)
        {
            throw new KeyNotFoundException("Employee not found");
        }
        employeeRepository.Delete(deleteEmployeeCommand.Id);
    }
}
