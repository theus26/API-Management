using API_PeopleManagement.Domain.Commands.Unit;
using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.employee;
using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Service.Employee;

public class UnitService(IBaseRepository<Unit> unitRepository, 
    IMapper mapper, UnitCommandHandler commandHandler) : IUnitService
{
    public async Task<EventInserted> CreateUnit(CreateUnitDto createPosition)
    {
        var unitCommand = mapper.Map<InsertUnitCommand>(createPosition);
        return await commandHandler.HandleCommand(unitCommand);
    }

    public IEnumerable<UnitDto> GetAllUnits()
    {
       var units = unitRepository.GetAll();
       return !units.Any() ? [] : mapper.Map<IEnumerable<UnitDto>>(units);
    }

    public void DeleteUnit(Guid unitId)
    {
        var deleteCommand = new DeleteUnitCommand(unitId);
        commandHandler.HandleCommand(deleteCommand);
    }
}