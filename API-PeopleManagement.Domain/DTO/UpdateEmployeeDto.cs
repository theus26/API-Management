namespace API_PeopleManagement.Domain.DTO;

public class UpdateEmployeeDto 
{
    public string? Name { get; set; }
    public string? Position { get; set; }
    public DateTime? AdmissionDate { get; set; }
    public double? Wage { get; set; }
    public bool IsActive { get; set; }
}