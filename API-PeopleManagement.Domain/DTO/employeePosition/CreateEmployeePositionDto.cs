namespace API_PeopleManagement.Domain.DTO.employeePosition;

public class CreateEmployeePositionDto
{
    public Guid EmployeeId { get; set; }
    public Guid PositionId { get; set; }
    public DateTime DateCreation { get; set; }
    
    
}