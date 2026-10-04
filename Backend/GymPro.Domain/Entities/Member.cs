namespace GymPro.Domain.Entities;
using GymPro.Domain.Enums;


public class Member : AuditableEntity
{
    public Guid GymId { get; set; }

    public string MemberCode { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public Gender? Gender { get; set; }

    public string Address { get; set; } = string.Empty;

    public string EmergencyContactName { get; set; } = string.Empty;

    public string EmergencyContactPhone { get; set; } = string.Empty;

    public DateTime JoinDate { get; set; } = DateTime.UtcNow;

    public MemberStatus Status { get; set; } = MemberStatus.Active;
    public string? ProfileImageUrl { get; set; }

    // Navigation properties
    public ICollection<MemberMembership> Memberships { get; set; } = new List<MemberMembership>();

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
