using API_PeopleManagement.Domain.Enum;

namespace API_PeopleManagement.Domain.Entities;

public class Users : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Roles Role { get; set; }
    public virtual ICollection<ChangeRecord> ChangeRecord { get; set; }
}