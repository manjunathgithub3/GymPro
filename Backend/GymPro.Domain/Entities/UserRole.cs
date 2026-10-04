namespace GymPro.Domain.Entities;

public class UserRole : BaseEntity
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public Guid GymId { get; set; }

    // Navigation properties
    public User? User { get; set; }

    public Role? Role { get; set; }

    public Gym? Gym { get; set; }
}
