namespace GymPro.Domain.Entities;
using GymPro.Domain.Enums;

public class Inquiry : AuditableEntity
{
    public Guid GymId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;


    public Guid? InterestedPlanId { get; set; }

    public DateTime? FollowUpDate { get; set; }

    public string Notes { get; set; } = string.Empty;

    public Guid? AssignedToUserId { get; set; }
    public InquirySource Source { get; set; }

    public InquiryStatus Status { get; set; } = InquiryStatus.New;

    // Navigation properties
    public Gym? Gym { get; set; }

    public MembershipPlan? InterestedPlan { get; set; }

    public User? AssignedToUser { get; set; }
}
