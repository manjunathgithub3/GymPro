using BCrypt.Net;
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
[Route("api/gyms")]
[Authorize(Roles = "SuperAdmin")]
public class GymController : ControllerBase
{
    private readonly GymProDbContext _context;

    public GymController(GymProDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGymRequest request)
    {
        if (await _context.Gyms.AnyAsync(x => x.Code == request.Code))
            return BadRequest("Gym code already exists.");

        if (await _context.Users.AnyAsync(x => x.Email == request.OwnerEmail))
            return BadRequest("Owner email already exists.");

        var gym = new Gym
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            Address = request.Address,
            City = request.City,
            State = request.State,
            Country = request.Country,
            PostalCode = request.PostalCode,
            Email = request.Email,
            Phone = request.Phone
        };

        var owner = new User
        {
            Id = Guid.NewGuid(),
            GymId = gym.Id,
            FirstName = request.OwnerFirstName,
            LastName = request.OwnerLastName,
            Email = request.OwnerEmail,
            Phone = request.OwnerPhone,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.OwnerPassword),
            IsActive = true
        };

        _context.Gyms.Add(gym);
        _context.Users.Add(owner);

        _context.UserRoles.Add(new UserRole
        {
            Id = Guid.NewGuid(),
            UserId = owner.Id,
            RoleId = RoleSeed.GymOwnerRoleId
        });

        await _context.SaveChangesAsync();

        return Ok(new
        {
            gymId = gym.Id,
            ownerId = owner.Id,
            message = "Gym and owner created successfully."
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var gyms = await _context.Gyms
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.Name)
            .ToListAsync();

        return Ok(gyms);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var gym = await _context.Gyms
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

        return gym is null ? NotFound() : Ok(gym);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateGymRequest request)
    {
        var gym = await _context.Gyms.FindAsync(id);

        if (gym is null || gym.IsDeleted)
            return NotFound();

        gym.Name = request.Name;
        gym.Address = request.Address;
        gym.City = request.City;
        gym.State = request.State;
        gym.Country = request.Country;
        gym.PostalCode = request.PostalCode;
        gym.Email = request.Email;
        gym.Phone = request.Phone;
        gym.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(gym);
    }
}
