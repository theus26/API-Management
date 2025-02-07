namespace API_PeopleManagement.Domain.Entities;

public class Positions : BaseEntity
{
    public string Position { get; set; }
    public double Wage { get; set; }
    public DateTime ChangeDate { get; set; }
    public virtual ICollection<EmployeePosition> EmployeePosition { get; set; }
}