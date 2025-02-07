using API_PeopleManagement.Domain.Commands.ChangeRecordDto;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Domain.Commands.ChangeRecord;

public class ChangeRecordCommandHandler(IBaseRepository<Entities.ChangeRecord> changeRecordRepository, IUnitOfWork unitOfWork, IMapper mapper) 
{
    public async Task<EventInserted> HandleCommand(InsertChangeRecordCommand insertChangeRecordCommand)
    {
        var changeRecord = mapper.Map<Entities.ChangeRecord>(insertChangeRecordCommand);
        var record = changeRecordRepository.Create(changeRecord);
        return await unitOfWork.Commit() ? new EventInserted(record.Id, true) 
            : new EventInserted(record.Id, false);
    }
}