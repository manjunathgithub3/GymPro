namespace GymPro.Domain.Entities;

public class Attendance : AuditableEntity
{
    public Guid GymId { get; set; }

    public Guid MemberId { get; set; }

    public DateTime CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public DateTime AttendanceDate { get; set; }

    public Guid? MarkedByUserId { get; set; }

    // Navigation properties
    public Gym? Gym { get; set; }

    public Member? Member { get; set; }

    public User? MarkedByUser { get; set; }
}
