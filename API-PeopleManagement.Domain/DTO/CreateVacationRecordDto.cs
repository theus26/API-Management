using API_PeopleManagement.Domain.Enum;

namespace API_PeopleManagement.Domain.DTO;

public class CreateVacationRecordDto
{
    public DateTime VacationStartDate { get; set; }
    public DateTime VacationeEndDate { get; set; }
    public VacationStatus VacationStatus { get; set; }
    public Guid EmployeesId { get; set; }
}