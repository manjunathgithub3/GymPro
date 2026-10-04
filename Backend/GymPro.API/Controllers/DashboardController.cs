using GymPro.Contracts.Responses;
using GymPro.Infrastructure.Identity;
using GymPro.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPro.API.Controllers;

[ApiController]
[Route("api/dashboard")]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly GymProDbContext _context;
    private readonly ICurrentUserService _currentUser;

    public DashboardController(GymProDbContext context, ICurrentUserService currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var today = DateTime.UtcNow.Date;

        var response = new DashboardResponse
        {
            TotalMembers = await _context.Members.CountAsync(x => x.GymId == gymId && !x.IsDeleted),
            ActiveMembers = await _context.Members.CountAsync(x => x.GymId == gymId && x.Status == Domain.Enums.MemberStatus.Active && !x.IsDeleted),
            ActiveMemberships = await _context.MemberMemberships.CountAsync(x => x.GymId == gymId && x.Status == Domain.Enums.MembershipStatus.Active && x.EndDate >= today && !x.IsDeleted),
            TodayAttendance = await _context.Attendances.CountAsync(x => x.GymId == gymId && x.AttendanceDate == today && !x.IsDeleted),
            ExpiringMemberships = await _context.MemberMemberships.CountAsync(x => x.GymId == gymId && x.Status == Domain.Enums.MembershipStatus.Active && x.EndDate >= today && x.EndDate <= today.AddDays(7) && !x.IsDeleted),
            NewInquiries = await _context.Inquiries.CountAsync(x => x.GymId == gymId && x.Status == Domain.Enums.InquiryStatus.New && !x.IsDeleted)
        };

        return Ok(response);
    }
}
