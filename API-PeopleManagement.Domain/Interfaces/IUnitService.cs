using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.employee;
using API_PeopleManagement.Domain.Events;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IUnitService
{
    Task<EventInserted> CreateUnit(CreateUnitDto createUnit);
    IEnumerable<UnitDto> GetAllUnits();
    UnitDto UpdateUnit(UnitDto updateUnit);
    void DeleteUnit(Guid unitId);
}