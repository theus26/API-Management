using API_PeopleManagement.Domain.DTO.employeePosition;
using API_PeopleManagement.Domain.DTO.vacations;

namespace API_PeopleManagement.Domain.DTO.employee;

public class ListEmployeeDto
{
    public Guid Id { get; set; }
    public string NameEmployee { get; set; }
    public string? CTPS { get; set; }
    public string? PisPasep { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Rg { get; set; }
    public string? Cpf { get; set; }
    public string? EmailEmployee { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Observations { get; set; }
    public string? BankDetails { get; set; }
    public bool IsActive { get; set; }
    public Guid? UnitId { get; set; }
    public virtual ICollection<EmployeePositionDto> EmployeePosition { get; set; }
    public virtual ICollection<VacationRecordDto> VacationRecord { get; set; }
    public virtual ICollection<ChangeRecordDto> ChangeRecords { get; set; }
}