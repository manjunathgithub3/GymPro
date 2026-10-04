using GymPro.Application.Interfaces;
using GymPro.Contracts.Requests;
using GymPro.Contracts.Responses;
using GymPro.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GymPro.Application.Services;

public class AuthService : IAuthService
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordService _passwordService;
    private readonly IJwtService _jwtService;
    private readonly JwtSettings _jwtSettings;

    public AuthService(
        IApplicationDbContext context,
        IPasswordService passwordService,
        IJwtService jwtService,
        IOptions<JwtSettings> jwtSettings)
    {
        _context = context;
        _passwordService = passwordService;
        _jwtService = jwtService;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users
            .Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x =>x.Email == request.Email && x.IsActive &&!x.IsDeleted);

        if (user is null || !_passwordService.VerifyPassword(request.Password,user.PasswordHash))
        {
            throw new UnauthorizedAccessException(
                "Invalid email or password."); 
        }

        var roles = user.UserRoles.Select(x => x.Role.Name).ToList();

        var accessToken =_jwtService.GenerateAccessToken(user, roles);

        var refreshToken = Guid.NewGuid().ToString("N");

        var refreshTokenEntity = new Domain.Entities.RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Token = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays)
        };

        user.LastLoginAt = DateTime.UtcNow;

        _context.RefreshTokens.Add(refreshTokenEntity);

        await _context.SaveChangesAsync();

        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            AccessTokenExpiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
            UserId = user.Id,
            Email = user.Email,
            Roles = roles
        };
    }

    public async Task<LoginResponse> RefreshTokenAsync(string refreshToken)
    {
        var token = await _context.RefreshTokens
            .Include(x => x.User)
                .ThenInclude(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Token == refreshToken);

        if (token is null ||
            token.RevokedAt.HasValue ||
            token.ExpiresAt <= DateTime.UtcNow ||
            !token.User.IsActive ||
            token.User.IsDeleted)
        {
            throw new UnauthorizedAccessException("Invalid refresh token.");
        }

        var roles = token.User.UserRoles.Select(x => x.Role.Name).ToList();

        var newAccessToken = _jwtService.GenerateAccessToken(token.User, roles);

        var newRefreshToken = Guid.NewGuid().ToString("N");

        token.RevokedAt = DateTime.UtcNow;
        token.ReplacedByToken = newRefreshToken;

        _context.RefreshTokens.Add(new Domain.Entities.RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = token.UserId,
            Token = newRefreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays)
        });

        await _context.SaveChangesAsync();

        return new LoginResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            AccessTokenExpiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
            UserId = token.User.Id,
            Email = token.User.Email,
            Roles = roles
        };
    }

    public async Task LogoutAsync(string refreshToken)
    {
        var token = await _context.RefreshTokens
            .FirstOrDefaultAsync(x => x.Token == refreshToken);

        if (token is null)
            return;

        token.RevokedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }
}