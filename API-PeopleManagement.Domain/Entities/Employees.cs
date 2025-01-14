namespace API_PeopleManagement.Domain.Entities;

public class Employees : BaseEntity
{
    public string Name { get; set; }
    public string Position { get; set; }
    public DateTime AdmissionDate { get; set; }
    public double Wage { get; set; }
    public bool IsActive { get; set; }
    public virtual ICollection<VacationRecord> VacationRecords { get; set; }
    public virtual ICollection<ChangeRecord> ChangeRecords { get; set; }
}