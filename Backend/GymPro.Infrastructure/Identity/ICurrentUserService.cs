namespace GymPro.Infrastructure.Identity;

public interface ICurrentUserService
{
    Guid? UserId { get; }
    Guid? GymId { get; }
    bool IsSuperAdmin { get; }
}
