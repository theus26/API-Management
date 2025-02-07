using API_PeopleManagement.Domain.DTO.position;
using API_PeopleManagement.Domain.Events;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IPositionService
{
    Task<EventInserted> CreatePosition(CreatePositionDto createPosition);
    void UpdatePosition(UpdatePositionDto updatePosition);
    IEnumerable<PositionDto> GetAllPositions();
    void DeletePosition(Guid positionId);
}