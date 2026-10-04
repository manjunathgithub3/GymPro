using GymPro.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GymPro.Application.Interfaces;

namespace GymPro.Persistence.DependencyInjection;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<GymProDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        // Expose IApplicationDbContext for Application layer
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<GymProDbContext>());

        return services;
    }
}