namespace API_PeopleManagement.Domain.Commands.Unit;

public class DeleteUnitCommand(Guid unitId)
{
    public Guid UnitId { get; set; } = unitId;
}