using GymPro.Shared;

namespace GymPro.Infrastructure.Identity;

public class PasswordService : GymPro.Shared.IPasswordService
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}