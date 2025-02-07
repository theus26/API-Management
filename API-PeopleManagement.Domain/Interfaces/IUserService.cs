using API_PeopleManagement.Domain.DTO.user;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IUserService
{
    string SignIn(string email, string password);
    UserDto GetUserInformationById(Guid userId);
}