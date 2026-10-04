using GymPro.Infrastructure.Identity;
using GymPro.Infrastructure.Jwt;
using GymPro.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymPro.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(
            configuration.GetSection("Jwt"));

        services.AddScoped<GymPro.Shared.IPasswordService, PasswordService>();
        services.AddScoped<GymPro.Shared.IJwtService, JwtService>();

        return services;
    }
}