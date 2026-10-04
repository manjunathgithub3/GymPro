using GymPro.Domain.Entities;

namespace GymPro.Infrastructure.Jwt;

public interface IJwtService
{
    string GenerateAccessToken(User user, IEnumerable<string> roles);
}