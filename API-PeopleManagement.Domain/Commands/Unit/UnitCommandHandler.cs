using API_PeopleManagement.Domain.Commands.Employee;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Domain.Commands.Unit;

public class UnitCommandHandler(IBaseRepository<Entities.Unit> unitRepository,IMapper mapper, IUnitOfWork unitOfWork)
{
    public async Task<EventInserted> HandleCommand(InsertUnitCommand insertUnitCommand)
    {
        var unitMapper = mapper.Map<Entities.Unit>(insertUnitCommand);
        var unit = unitRepository.Create(unitMapper);
        return await unitOfWork.Commit() ? new EventInserted(unit.Id, true) 
            : new EventInserted(unit.Id, false);
    }
    
    public void HandleCommand(DeleteUnitCommand deleteUnitCommand)
    {
        var employee = unitRepository.Get(deleteUnitCommand.UnitId);
        if (employee == null)
        {
            throw new KeyNotFoundException("Employee not found");
        }
        unitRepository.Delete(deleteUnitCommand.UnitId);
    }
}