using GymPro.Contracts.Requests;
using GymPro.Domain.Entities;
using GymPro.Infrastructure.Identity;
using GymPro.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPro.API.Controllers;

[ApiController]
[Route("api/attendance")]
[Authorize]
public class AttendanceController : ControllerBase
{
    private readonly GymProDbContext _context;
    private readonly ICurrentUserService _currentUser;

    public AttendanceController(GymProDbContext context, ICurrentUserService currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    [HttpPost("check-in")]
    public async Task<IActionResult> CheckIn([FromBody] CheckInRequest request)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var attendance = new Attendance
        {
            Id = Guid.NewGuid(),
            GymId = gymId.Value,
            MemberId = request.MemberId,
            AttendanceDate = DateTime.UtcNow.Date,
            CheckInTime = DateTime.UtcNow,
            MarkedByUserId = _currentUser.UserId
        };

        _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();

        return Ok(attendance);
    }

    [HttpPost("{id:guid}/check-out")]
    public async Task<IActionResult> CheckOut(Guid id)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var attendance = await _context.Attendances.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        if (attendance is null) return NotFound();

        attendance.CheckOutTime = DateTime.UtcNow;
        attendance.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(attendance);
    }

    [HttpGet("today")]
    public async Task<IActionResult> Today()
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var today = DateTime.UtcNow.Date;

        var attendances = await _context.Attendances
            .Where(x => x.GymId == gymId && x.AttendanceDate == today && !x.IsDeleted)
            .ToListAsync();

        return Ok(attendances);
    }
}
