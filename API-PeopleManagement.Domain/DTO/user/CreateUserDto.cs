using API_PeopleManagement.Domain.Enum;

namespace API_PeopleManagement.Domain.DTO.user;

public class CreateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Roles Role { get; set; }
}