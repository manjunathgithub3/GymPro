using GymPro.Domain.Entities;
using System.Collections.Generic;

namespace GymPro.Shared;

public interface IJwtService
{
    string GenerateAccessToken(User user, IEnumerable<string> roles);
}
