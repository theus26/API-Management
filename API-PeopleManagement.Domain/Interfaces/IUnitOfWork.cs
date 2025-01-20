using API_PeopleManagement.Domain.Entities;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<Employees> EmployeesRepository { get; }
    IBaseRepository<ChangeRecord> ChangeRecordRepository { get; }
    IBaseRepository<VacationRecord> VacationsRecordsRepository { get; }
    Task<bool> Commit();
    
}