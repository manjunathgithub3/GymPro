using GymPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymPro.Persistence.Configurations;

public class TrainerProfileConfiguration
    : IEntityTypeConfiguration<TrainerProfile>
{
    public void Configure(EntityTypeBuilder<TrainerProfile> builder)
    {
        builder.ToTable("TrainerProfiles");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Specialization)
            .HasMaxLength(200);

        builder.Property(x => x.Bio)
            .HasMaxLength(1000);

        builder.Property(x => x.ExperienceYears)
            .IsRequired();

        builder.Property(x => x.JoiningDate)
            .IsRequired();

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        builder.HasIndex(x => x.GymId);

        builder.HasOne(x => x.Gym)
            .WithMany()
            .HasForeignKey(x => x.GymId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}