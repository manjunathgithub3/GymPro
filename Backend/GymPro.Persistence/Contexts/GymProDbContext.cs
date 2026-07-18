using GymPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymPro.Persistence.Contexts;

public class GymProDbContext : DbContext
{
    public GymProDbContext(DbContextOptions<GymProDbContext> options)
        : base(options)
    {
    }

    public DbSet<Gym> Gyms => Set<Gym>();
}