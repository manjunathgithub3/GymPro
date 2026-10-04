using GymPro.Contracts.Requests;
using GymPro.Domain.Entities;
using GymPro.Infrastructure.Identity;
using GymPro.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPro.API.Controllers;

[ApiController]
[Route("api/memberships")]
[Authorize]
public class MembershipsController : ControllerBase
{
    private readonly GymProDbContext _context;
    private readonly ICurrentUserService _currentUser;

    public MembershipsController(GymProDbContext context, ICurrentUserService currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    [HttpPost]
    public async Task<IActionResult> Assign([FromBody] AssignMembershipRequest request)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var member = await _context.Members.FirstOrDefaultAsync(x => x.Id == request.MemberId && x.GymId == gymId && !x.IsDeleted);
        var plan = await _context.MembershipPlans.FirstOrDefaultAsync(x => x.Id == request.MembershipPlanId && x.GymId == gymId && !x.IsDeleted);

        if (member is null || plan is null) return NotFound();

        var membership = new MemberMembership
        {
            Id = Guid.NewGuid(),
            GymId = gymId.Value,
            MemberId = member.Id,
            MembershipPlanId = plan.Id,
            StartDate = request.StartDate,
            EndDate = request.StartDate.AddDays(plan.DurationInDays),
            Status = Domain.Enums.MembershipStatus.Active
        };

        _context.MemberMemberships.Add(membership);
        await _context.SaveChangesAsync();

        return Ok(membership);
    }

    [HttpGet("member/{memberId:guid}")]
    public async Task<IActionResult> GetByMember(Guid memberId)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var memberships = await _context.MemberMemberships.Where(x => x.MemberId == memberId && x.GymId == gymId && !x.IsDeleted).ToListAsync();
        return Ok(memberships);
    }

    [HttpPost("{id:guid}/renew")]
    public async Task<IActionResult> Renew(Guid id)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var membership = await _context.MemberMemberships.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        if (membership is null) return NotFound();

        var plan = await _context.MembershipPlans.FirstOrDefaultAsync(x => x.Id == membership.MembershipPlanId && x.GymId == gymId && !x.IsDeleted);
        if (plan is null) return NotFound();

        membership.EndDate = membership.EndDate.AddDays(plan.DurationInDays);
        membership.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(membership);
    }

    [HttpPost("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var membership = await _context.MemberMemberships.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        if (membership is null) return NotFound();

        membership.Status = Domain.Enums.MembershipStatus.Cancelled;
        membership.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(membership);
    }
}
