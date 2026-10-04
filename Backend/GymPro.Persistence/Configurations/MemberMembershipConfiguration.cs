using GymPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymPro.Persistence.Configurations;

public class MemberMembershipConfiguration
    : IEntityTypeConfiguration<MemberMembership>
{
    public void Configure(EntityTypeBuilder<MemberMembership> builder)
    {
        builder.ToTable("MemberMemberships");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();

        builder.HasIndex(x => x.GymId);

        builder.HasIndex(x => x.MemberId);

        builder.HasIndex(x => x.MembershipPlanId);

        builder.HasOne(x => x.Gym)
            .WithMany()
            .HasForeignKey(x => x.GymId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Member)
            .WithMany(x => x.Memberships)
            .HasForeignKey(x => x.MemberId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.MembershipPlan)
            .WithMany(x => x.MemberMemberships)
            .HasForeignKey(x => x.MembershipPlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}