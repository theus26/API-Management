using API_PeopleManagement.Domain.Commands.ChangeRecord;
using API_PeopleManagement.Domain.Commands.ChangeRecordDto;
using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Service.ChangeRecord;

public class ChangeRecordService(IBaseRepository<Domain.Entities.ChangeRecord> changeRecordRepository, IMapper mapper, ChangeRecordCommandHandler recordCommandHandler) : IChangeRecordsService
{
    public void AddChangeRecord(ChangeRecordDto changeRecord)
    {
        var changeRecords = mapper.Map<InsertChangeRecordCommand>(changeRecord);
        _ = recordCommandHandler.HandleCommand(changeRecords);
    }
}

