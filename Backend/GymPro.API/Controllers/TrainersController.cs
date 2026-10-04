using GymPro.Contracts.Requests;
using GymPro.Domain.Entities;
using GymPro.Infrastructure.Identity;
using GymPro.Persistence.Contexts;
using GymPro.Persistence.Seed;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPro.API.Controllers;

[ApiController]
[Route("api/trainers")]
[Authorize]
public class TrainersController : ControllerBase
{
    private readonly GymProDbContext _context;
    private readonly ICurrentUserService _currentUser;

    public TrainersController(GymProDbContext context, ICurrentUserService currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTrainerRequest request)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        if (await _context.Users.AnyAsync(x => x.Email == request.Email))
            return BadRequest("Email already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            GymId = gymId.Value,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            IsActive = true
        };

        var profile = new TrainerProfile
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            GymId = gymId.Value,
            Specialization = request.Specialization,
            ExperienceYears = request.ExperienceYears,
            Bio = request.Bio
        };

        _context.Users.Add(user);
        _context.TrainerProfiles.Add(profile);
        _context.UserRoles.Add(new UserRole
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            RoleId = RoleSeed.TrainerRoleId
        });

        await _context.SaveChangesAsync();

        return Ok(new { user, profile });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var trainers = await _context.TrainerProfiles.Where(x => x.GymId == gymId && !x.IsDeleted).ToListAsync();
        return Ok(trainers);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var trainer = await _context.TrainerProfiles.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        return trainer is null ? NotFound() : Ok(trainer);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateTrainerRequest request)
    {
        var gymId = _currentUser.GymId;
        if (gymId == null) return BadRequest("User is not associated with a gym.");

        var profile = await _context.TrainerProfiles.FirstOrDefaultAsync(x => x.Id == id && x.GymId == gymId && !x.IsDeleted);
        if (profile is null) return NotFound();

        profile.Specialization = request.Specialization;
        profile.ExperienceYears = request.ExperienceYears;
        profile.Bio = request.Bio;
        profile.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(profile);
    }
}
