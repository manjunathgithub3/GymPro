using GymPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymPro.Persistence.Seed;

public static class RoleSeed
{
    public static readonly Guid SuperAdminRoleId =
        Guid.Parse("10000000-0000-0000-0000-000000000001");

    public static readonly Guid GymOwnerRoleId =
        Guid.Parse("10000000-0000-0000-0000-000000000002");

    public static readonly Guid ManagerRoleId =
        Guid.Parse("10000000-0000-0000-0000-000000000003");

    public static readonly Guid ReceptionistRoleId =
        Guid.Parse("10000000-0000-0000-0000-000000000004");

    public static readonly Guid TrainerRoleId =
        Guid.Parse("10000000-0000-0000-0000-000000000005");

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = SuperAdminRoleId,
                Name = "SuperAdmin"
            },
            new Role
            {
                Id = GymOwnerRoleId,
                Name = "GymOwner"
            },
            new Role
            {
                Id = ManagerRoleId,
                Name = "Manager"
            },
            new Role
            {
                Id = ReceptionistRoleId,
                Name = "Receptionist"
            },
            new Role
            {
                Id = TrainerRoleId,
                Name = "Trainer"
            });
    }
}