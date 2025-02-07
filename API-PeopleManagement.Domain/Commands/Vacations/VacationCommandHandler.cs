using API_PeopleManagement.Domain.Commands.ChangeRecordDto;
using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Domain.Commands.Vacations;

public class VacationCommandHandler(IBaseRepository<VacationRecord> vacationsRepository, IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<EventInserted> HandleCommand(InsertVacationsCommand insertChangeRecordCommand)
    {
        var vacation = mapper.Map<VacationRecord>(insertChangeRecordCommand);
        var vacationCreated = vacationsRepository.Create(vacation);
        return await unitOfWork.Commit() ? new EventInserted(vacationCreated.Id, true) 
            : new EventInserted(vacationCreated.Id, false);
    }
}