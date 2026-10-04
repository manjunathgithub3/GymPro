namespace GymPro.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public Guid UserId { get; set; }

    // Navigation property to the owning User
    public User? User { get; set; }

    public string Token { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? RevokedAt { get; set; }

    public string? ReplacedByToken { get; set; }
}
