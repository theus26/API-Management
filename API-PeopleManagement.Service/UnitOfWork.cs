using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Interfaces;
using API_PeopleManagement.Infra.Data.Context;

namespace API_PeopleManagement.Service;

public class UnitOfWork : IUnitOfWork
{
    private readonly PeopleManagementContext _context;
    
    public UnitOfWork(IBaseRepository<Employees> employeesRepository, IBaseRepository<Domain.Entities.ChangeRecord> changeRecordRepository, IBaseRepository<VacationRecord> vacationsRecordsRepository, PeopleManagementContext context)
    {
        EmployeesRepository = employeesRepository;
        ChangeRecordRepository = changeRecordRepository;
        VacationsRecordsRepository = vacationsRecordsRepository;
        _context = context;
    }
    
    public IBaseRepository<Employees> EmployeesRepository { get; }
    public IBaseRepository<Domain.Entities.ChangeRecord> ChangeRecordRepository { get; }
    public IBaseRepository<VacationRecord> VacationsRecordsRepository { get; }
    public async Task<bool> Commit()
    {
        return  _context.SaveChangesAsync().IsCompletedSuccessfully;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}