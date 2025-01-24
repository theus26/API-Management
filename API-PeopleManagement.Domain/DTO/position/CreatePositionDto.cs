namespace API_PeopleManagement.Domain.DTO.position;

public class CreatePositionDto
{
    public string Position { get; set; }
    public double Wage { get; set; }
    public DateTime ChangeDate { get; set; }
}