using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Domain.Commands.Employee;

public class EmployeeCommandHandler (IBaseRepository<Employees> employeeRepository, IUnitOfWork unitOfWork, IMapper mapper)  
{
    public async Task<EmployeeInsertedEvent> HandleCommand(InsertEmployeeCommand employeeCommand)
    {
        var employeeMapper = mapper.Map<Employees>(employeeCommand);
        var employee = employeeRepository.Create(employeeMapper);
        return await unitOfWork.Commit() ? new EmployeeInsertedEvent(employee.Id, true) 
            : new EmployeeInsertedEvent(employee.Id, false);
    }
}
