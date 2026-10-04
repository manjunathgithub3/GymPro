using GymPro.Contracts.Requests;
using GymPro.Domain.Entities;
using GymPro.Infrastructure.Identity;
using GymPro.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPro.API.Controllers;

[ApiController]
[Route("api/membership-plans")]
[Authorize]
public class MembershipPlansController : ControllerBase
{
    private readonly GymProDbContext _context;
    private readonly ICurrentUserService _currentUser;

    public MembershipPlansController(GymProDbContext context, ICurrentUserService currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMembershipPlanRequest request)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var plan = new MembershipPlan
        {
            Id = Guid.NewGuid(),
            GymId = gymId.Value,
            Name = request.Name,
            Description = request.Description,
            DurationInDays = request.DurationInDays,
            Price = request.Price
        };

        _context.MembershipPlans.Add(plan);
        await _context.SaveChangesAsync();

        return Ok(plan);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var plans = await _context.MembershipPlans.Where(x => x.GymId == gymId && !x.IsDeleted).ToListAsync();
        return Ok(plans);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var plan = await _context.MembershipPlans.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        return plan is null ? NotFound() : Ok(plan);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateMembershipPlanRequest request)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var plan = await _context.MembershipPlans.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        if (plan is null) return NotFound();

        plan.Name = request.Name;
        plan.Description = request.Description;
        plan.DurationInDays = request.DurationInDays;
        plan.Price = request.Price;
        plan.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(plan);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var plan = await _context.MembershipPlans.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        if (plan is null) return NotFound();

        plan.IsDeleted = true;
        plan.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(new { message = "Deleted" });
    }
}
