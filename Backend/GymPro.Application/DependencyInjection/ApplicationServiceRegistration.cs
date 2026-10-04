using GymPro.Application.Interfaces;
using GymPro.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GymPro.Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
