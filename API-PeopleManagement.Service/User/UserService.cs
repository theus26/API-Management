using System.Security.Cryptography;
using System.Text;
using API_PeopleManagement.Domain.DTO.user;
using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;

namespace API_PeopleManagement.Service.User;

public class UserService(IBaseRepository<Users> userRepository, ITokenService tokenService, IMapper mapper) : IUserService
{
    public string SignIn(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Invalid email or password");
        }
        var passwordHashed = CreateHashMd5(password);
        var users = userRepository.GetAll().FirstOrDefault(u => u.Email == email && u.Password == passwordHashed);
        if (users is not null)
        {
            return tokenService.GenerateToken(users!.Id, users.Role);
        }
        throw new ArgumentException("User not found");
    }

    public UserDto GetUserInformationById(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("Invalid user id");
        }
        var users = userRepository.Get(userId);
        if (users is null)
        {
            throw new ArgumentException("User not found");
        }
        return mapper.Map<UserDto>(users);
    }

    private static string CreateHashMd5(string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var sBuilder = new StringBuilder();
        foreach (var t in data)
        {
            sBuilder.Append(t.ToString("x2"));
        }
        return sBuilder.ToString();
    }
}