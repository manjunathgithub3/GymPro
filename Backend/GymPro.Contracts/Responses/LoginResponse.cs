namespace GymPro.Contracts.Responses;

public class LoginResponse
{
    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime AccessTokenExpiresAt { get; set; }

    public Guid UserId { get; set; }

    public string Email { get; set; } = string.Empty;

    public List<string> Roles { get; set; } = new();
}