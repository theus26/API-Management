namespace API_PeopleManagement.Domain.DTO;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public DateTime AdmissionDate { get; set; }
    public double Wage { get; set; }
    public bool IsActive { get; set; }
    public virtual ICollection<VacationRecordDto> VacationRecords { get; set; }
}