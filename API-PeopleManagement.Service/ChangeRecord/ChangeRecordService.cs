using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Service.ChangeRecord;

public class ChangeRecordService(IBaseRepository<Domain.Entities.ChangeRecord> changeRecordRepository, IMapper mapper) : IChangeRecordsService
{
    public void AddChangeRecord(ChangeRecordDto changeRecord)
    {
        var changeRecords = mapper.Map<Domain.Entities.ChangeRecord>(changeRecord);
        changeRecordRepository.Create(changeRecords);
    }
}