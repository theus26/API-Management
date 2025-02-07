namespace API_PeopleManagement.Domain.Commands.EmployeePosition;

public class InsertEmployeePositionCommand(Guid employeeId, Guid positionId)
{
    public Guid EmployeeId { get; set; } = employeeId;
    public Guid PositionId { get; set; } = positionId;
    public DateTime DateCreation { get; set; } = DateTime.UtcNow;
}