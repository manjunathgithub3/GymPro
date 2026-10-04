using GymPro.Domain.Entities;
using GymPro.Persistence.Contexts;
using GymPro.Persistence.Seed;
using Microsoft.AspNetCore.Mvc;

namespace GymPro.API.Controllers;

[ApiController]
[Route("api/dev")]
public class DevController : ControllerBase
{
    private readonly GymProDbContext _context;

    public DevController(GymProDbContext context)
    {
        _context = context;
    }

    [HttpPost("create-admin")]
    public async Task<IActionResult> CreateAdmin()
    {
        var email = "admin@gympro.com";

        if (_context.Users.Any(x => x.Email == email))
            return BadRequest("Admin already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            GymId = null,
            FirstName = "GymPro",
            LastName = "Admin",
            Email = email,
            Phone = "9999999999",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            IsActive = true
        };

        _context.Users.Add(user);

        _context.UserRoles.Add(new UserRole
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            RoleId = RoleSeed.SuperAdminRoleId
        });

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Admin created",
            email,
            password = "Admin@123"
        });
    }
}
