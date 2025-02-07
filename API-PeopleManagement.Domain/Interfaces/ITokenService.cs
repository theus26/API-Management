using API_PeopleManagement.Domain.Enum;

namespace API_PeopleManagement.Domain.Interfaces;

public interface ITokenService
{
    public string GenerateToken(Guid userId, Roles role);
}