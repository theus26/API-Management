namespace API_PeopleManagement.Domain.Commands.Position;

public class UpdatePositionCommand
{
    public Guid Id { get; set; }
    public string? Position { get; set; }
    public double? Wage { get; set; }
    public DateTime? ChangeDate { get; set; }
}