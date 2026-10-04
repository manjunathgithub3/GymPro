using GymPro.Contracts.Requests;
using GymPro.Domain.Entities;
using GymPro.Infrastructure.Identity;
using GymPro.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPro.API.Controllers;

[ApiController]
[Route("api/inquiries")]
[Authorize]
public class InquiriesController : ControllerBase
{
    private readonly GymProDbContext _context;
    private readonly ICurrentUserService _currentUser;

    public InquiriesController(GymProDbContext context, ICurrentUserService currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Inquiry request)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var inquiry = new Inquiry
        {
            Id = Guid.NewGuid(),
            GymId = gymId.Value,
            Name = request.Name,
            Phone = request.Phone,
            Email = request.Email,
            InterestedPlanId = request.InterestedPlanId,
            FollowUpDate = request.FollowUpDate,
            Notes = request.Notes,
            AssignedToUserId = _currentUser.UserId,
            Source = request.Source,
            Status = request.Status
        };

        _context.Inquiries.Add(inquiry);
        await _context.SaveChangesAsync();

        return Ok(inquiry);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var items = await _context.Inquiries.Where(x => x.GymId == gymId && !x.IsDeleted).ToListAsync();
        return Ok(items);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var item = await _context.Inquiries.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Inquiry request)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var item = await _context.Inquiries.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        if (item is null) return NotFound();

        item.Name = request.Name;
        item.Phone = request.Phone;
        item.Email = request.Email;
        item.InterestedPlanId = request.InterestedPlanId;
        item.FollowUpDate = request.FollowUpDate;
        item.Notes = request.Notes;
        item.AssignedToUserId = request.AssignedToUserId;
        item.Source = request.Source;
        item.Status = request.Status;
        item.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(item);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var item = await _context.Inquiries.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        if (item is null) return NotFound();

        item.IsDeleted = true;
        item.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(new { message = "Deleted" });
    }

    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateInquiryStatusRequest request)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var item = await _context.Inquiries.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        if (item is null) return NotFound();

        item.Status = request.Status;
        item.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(item);
    }
}
