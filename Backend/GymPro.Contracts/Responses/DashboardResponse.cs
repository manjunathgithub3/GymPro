namespace GymPro.Contracts.Responses;

public class DashboardResponse
{
    public int TotalMembers { get; set; }
    public int ActiveMembers { get; set; }
    public int ActiveMemberships { get; set; }
    public int TodayAttendance { get; set; }
    public int ExpiringMemberships { get; set; }
    public int NewInquiries { get; set; }
}
