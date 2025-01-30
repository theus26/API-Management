using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Domain.Commands.ChangeRecordDto;

public class ChangeRecordCommandHandler(IBaseRepository<ChangeRecord> changeRecordRepository, IUnitOfWork unitOfWork, IMapper mapper) 
{
    public async Task<EventInserted> HandleCommand(InsertChangeRecordCommand insertChangeRecordCommand)
    {
        var changeRecord = mapper.Map<ChangeRecord>(insertChangeRecordCommand);
        var record = changeRecordRepository.Create(changeRecord);
        return await unitOfWork.Commit() ? new EventInserted(record.Id, true) 
            : new EventInserted(record.Id, false);
    }
}