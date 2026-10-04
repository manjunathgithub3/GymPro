using GymPro.Contracts.Requests;
using GymPro.Domain.Entities;
using GymPro.Infrastructure.Identity;
using GymPro.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPro.API.Controllers;

[ApiController]
[Route("api/members")]
[Authorize]
public class MembersController : ControllerBase
{
    private readonly GymProDbContext _context;
    private readonly ICurrentUserService _currentUser;

    public MembersController(GymProDbContext context, ICurrentUserService currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMemberRequest request)
    {
        var gymId = _currentUser.GymId;

        if (gymId == null)
            return BadRequest("User is not associated with a gym.");

        var member = new Member
        {
            Id = Guid.NewGuid(),
            GymId = gymId.Value,
            MemberCode = Guid.NewGuid().ToString("N").Substring(0, 8),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            Address = request.Address,
            EmergencyContactName = request.EmergencyContactName ?? string.Empty,
            EmergencyContactPhone = request.EmergencyContactPhone ?? string.Empty,
            JoinDate = DateTime.UtcNow,
            Status = Domain.Enums.MemberStatus.Active
        };

        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return Ok(member);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var gymId = _currentUser.GymId;

        if (gymId == null)
            return BadRequest("User is not associated with a gym.");

        var members = await _context.Members
            .Where(x => x.GymId == gymId && !x.IsDeleted)
            .ToListAsync();

        return Ok(members);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var gymId = _currentUser.GymId;

        if (gymId == null)
            return BadRequest("User is not associated with a gym.");

        var member = await _context.Members
            .FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);

        return member is null ? NotFound() : Ok(member);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMemberRequest request)
    {
        var gymId = _currentUser.GymId;

        if (gymId == null)
            return BadRequest("User is not associated with a gym.");

        var member = await _context.Members.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);

        if (member is null)
            return NotFound();

        member.FirstName = request.FirstName;
        member.LastName = request.LastName;
        member.Email = request.Email;
        member.Phone = request.Phone;
        member.DateOfBirth = request.DateOfBirth;
        member.Gender = request.Gender;
        member.Address = request.Address;
        member.EmergencyContactName = request.EmergencyContactName ?? string.Empty;
        member.EmergencyContactPhone = request.EmergencyContactPhone ?? string.Empty;
        member.Status = request.Status;
        member.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(member);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var gymId = _currentUser.GymId;

        if (gymId == null)
            return BadRequest("User is not associated with a gym.");

        var member = await _context.Members.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);

        if (member is null)
            return NotFound();

        member.IsDeleted = true;
        member.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(new { message = "Deleted" });
    }
}
