namespace GymPro.Domain.Entities;

public class MembershipPlan : AuditableEntity
{
    public Guid GymId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DurationInDays { get; set; }

    public decimal Price { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation properties
    public Gym? Gym { get; set; }

    public ICollection<MemberMembership> MemberMemberships { get; set; } = new List<MemberMembership>();

    public ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();
}
