using API_PeopleManagement.Domain.DTO.employee;
using API_PeopleManagement.Domain.DTO.position;

namespace API_PeopleManagement.Domain.DTO.employeePosition;

public class EmployeePositionDto
{
    public virtual PositionDto Positions { get;  set; }
    public DateTime DateCreation { get; set; }
}