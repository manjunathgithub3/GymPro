using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace GymPro.Infrastructure.Identity;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? UserId
    {
        get
        {
            var value = _httpContextAccessor.HttpContext?
                .User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Guid.TryParse(value, out var id) ? id : null;
        }
    }

    public Guid? GymId
    {
        get
        {
            var value = _httpContextAccessor.HttpContext?
                .User?.FindFirst("GymId")?.Value;

            return Guid.TryParse(value, out var id) ? id : null;
        }
    }

    public bool IsSuperAdmin =>
        _httpContextAccessor.HttpContext?
            .User.IsInRole("SuperAdmin") ?? false;
}
