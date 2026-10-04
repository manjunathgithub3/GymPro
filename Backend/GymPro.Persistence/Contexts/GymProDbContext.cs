using GymPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GymPro.Persistence.Seed;
using GymPro.Application.Interfaces;

namespace GymPro.Persistence.Contexts;

public class GymProDbContext : DbContext, IApplicationDbContext
{
    public GymProDbContext(DbContextOptions<GymProDbContext> options)
        : base(options)
    {
    }

    public DbSet<Gym> Gyms => Set<Gym>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<MembershipPlan> MembershipPlans => Set<MembershipPlan>();
    public DbSet<MemberMembership> MemberMemberships => Set<MemberMembership>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<TrainerProfile> TrainerProfiles => Set<TrainerProfile>();
    public DbSet<Inquiry> Inquiries => Set<Inquiry>();

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(GymProDbContext).Assembly);
            RoleSeed.Seed(modelBuilder);
    }

}