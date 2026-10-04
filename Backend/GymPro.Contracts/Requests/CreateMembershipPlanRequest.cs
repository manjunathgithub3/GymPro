namespace GymPro.Contracts.Requests;

public class CreateMembershipPlanRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DurationInDays { get; set; }
    public decimal Price { get; set; }
}
