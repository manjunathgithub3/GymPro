using GymPro.Contracts.Requests;
using GymPro.Contracts.Responses;

namespace GymPro.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<LoginResponse> RefreshTokenAsync(string refreshToken);
    Task LogoutAsync(string refreshToken);
}