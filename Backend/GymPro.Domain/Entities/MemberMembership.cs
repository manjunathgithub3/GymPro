namespace GymPro.Domain.Entities;
using GymPro.Domain.Enums;


public class MemberMembership : AuditableEntity
{
    public Guid GymId { get; set; }

    public Guid MemberId { get; set; }

    public Guid MembershipPlanId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public MembershipStatus  Status { get; set; } = MembershipStatus.Active;

    // Navigation properties
    public Gym? Gym { get; set; }

    public Member? Member { get; set; }

    public MembershipPlan? MembershipPlan { get; set; }
}
