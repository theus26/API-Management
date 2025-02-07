using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Domain.Commands.Position;

public class PositionCommandHandler(IBaseRepository<Positions> positionRepository, IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<EventInserted> HandleCommand(InsertPositionCommand insertPositionCommand)
    {
        var positionMappers = mapper.Map<Positions>(insertPositionCommand);
        var positions = positionRepository.Create(positionMappers);
        return await unitOfWork.Commit() ? new EventInserted(positions.Id, true) 
            : new EventInserted(positions.Id, false);
    }
    
    public void HandleCommand(DeletePositionCommand deletePositionCommand)
    {
        var employee = positionRepository.Get(deletePositionCommand.Id);
        if (employee == null)
        {
            throw new KeyNotFoundException("Position not found");
        }
        positionRepository.Delete(deletePositionCommand.Id);
    }
    
    public void HandleCommand(UpdatePositionCommand updatePositionCommand)
    {
        var positions = positionRepository.Get(updatePositionCommand.Id);
        if (positions == null)
        {
            throw new KeyNotFoundException("Position not found");
        }
        positions.Position = updatePositionCommand.Position ?? positions.Position;
        positions.Wage = updatePositionCommand?.Wage ?? positions.Wage;
        positions.ChangeDate = updatePositionCommand?.ChangeDate ?? positions.ChangeDate;
        positionRepository.Update(positions);
    }
}