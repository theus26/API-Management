using API_PeopleManagement.Domain.Commands.Employee;
using API_PeopleManagement.Domain.Commands.Position;
using API_PeopleManagement.Domain.DTO.position;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_PeopleManagement.Service.Positions;

public class PositionService(IBaseRepository<Domain.Entities.Positions> positionRepository, PositionCommandHandler commandHandler, IMapper mapper) : IPositionService
{
    public async Task<EventInserted> CreatePosition(CreatePositionDto createPosition)
    {
        var insertPositionCommand = mapper.Map<InsertPositionCommand>(createPosition);
        return await commandHandler.HandleCommand(insertPositionCommand);
    }

    public void UpdatePosition(UpdatePositionDto updatePosition)
    {
       var updatePositionCommand = mapper.Map<UpdatePositionCommand>(updatePosition);
       commandHandler.HandleCommand(updatePositionCommand);
    }

    public IEnumerable<PositionDto> GetAllPositions()
    {
        var positions = positionRepository.GetAll().AsNoTracking();

        if (!positions.Any())
        {
            throw new Exception("No positions found");
        }
        return mapper.Map<List<PositionDto>>(positions);
    }

    public void DeletePosition(Guid positionId)
    {
        if (positionId == Guid.Empty)
        {
            throw new KeyNotFoundException("Please, enter a valid positionId ID");
        }
        var deletePositionCommand = new DeletePositionCommand(positionId);
        commandHandler.HandleCommand(deletePositionCommand);
    }
}