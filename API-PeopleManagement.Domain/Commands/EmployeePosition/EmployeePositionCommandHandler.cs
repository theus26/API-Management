using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Domain.Commands.EmployeePosition;

public class EmployeePositionCommandHandler(IBaseRepository<Entities.EmployeePosition> employeePositionrepository, IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<EventInserted> HandleCommand(InsertEmployeePositionCommand insertEmployeePositionCommand)
    {
        var employeePositionMapper = mapper.Map<Entities.EmployeePosition>(insertEmployeePositionCommand);
        var employee = employeePositionrepository.Create(employeePositionMapper);
        return await unitOfWork.Commit() ? new EventInserted(employee.Id, true) 
            : new EventInserted(employee.Id, false);
    }
}