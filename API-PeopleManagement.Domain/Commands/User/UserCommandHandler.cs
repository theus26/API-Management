using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Domain.Commands.User;

public class UserCommandHandler(IBaseRepository<Users> employeeRepository, IUnitOfWork unitOfWork, IMapper mapper) 
{
    public async Task<EventInserted> HandleCommand(InsertUserCommand insertUserCommand)
    {
        var usersMappers = mapper.Map<Users>(insertUserCommand);
        var user = employeeRepository.Create(usersMappers);
        return await unitOfWork.Commit() ? new EventInserted(user.Id, true) 
            : new EventInserted(user.Id, false);
    }
}