using API_PeopleManagement.Domain.DTO;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IChangeRecordsService
{
    void AddChangeRecord(ChangeRecordDto changeRecord);
}