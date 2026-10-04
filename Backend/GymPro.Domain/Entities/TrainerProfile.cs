namespace GymPro.Domain.Entities;

public class TrainerProfile : AuditableEntity
{
    public Guid UserId { get; set; }

    public Guid GymId { get; set; }

    public string Specialization { get; set; } = string.Empty;

    public int ExperienceYears { get; set; }

    public string Bio { get; set; } = string.Empty;

    public DateTime JoiningDate { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; } = true;

    // Navigation properties
    public User? User { get; set; }

    public Gym? Gym { get; set; }
}
