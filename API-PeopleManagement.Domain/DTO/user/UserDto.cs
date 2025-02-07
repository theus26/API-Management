using API_PeopleManagement.Domain.Enum;

namespace API_PeopleManagement.Domain.DTO.user;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}