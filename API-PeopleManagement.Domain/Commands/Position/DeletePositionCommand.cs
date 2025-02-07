namespace API_PeopleManagement.Domain.Commands.Position;

public class DeletePositionCommand(Guid id)
{
    public Guid Id { get; set; } = id;
}