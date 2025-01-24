namespace API_PeopleManagement.Domain.DTO.position;

public class PositionDto
{
    public Guid Id { get; set; }
    public string Position { get; set; }
    public double Wage { get; set; }
    public DateTime ChangeDate { get; set; }
}