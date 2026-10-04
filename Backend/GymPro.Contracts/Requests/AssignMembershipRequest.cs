namespace GymPro.Contracts.Requests;

public class AssignMembershipRequest
{
    public Guid MemberId { get; set; }
    public Guid MembershipPlanId { get; set; }
    public DateTime StartDate { get; set; }
}
