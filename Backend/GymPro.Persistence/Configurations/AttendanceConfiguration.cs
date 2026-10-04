using GymPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymPro.Persistence.Configurations;

public class AttendanceConfiguration
    : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendances");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AttendanceDate)
            .IsRequired();

        builder.Property(x => x.CheckInTime)
            .IsRequired();

        builder.HasIndex(x => new
        {
            x.GymId,
            x.AttendanceDate
        });

        builder.HasIndex(x => new
        {
            x.GymId,
            x.MemberId
        });

        builder.HasOne(x => x.Gym)
            .WithMany()
            .HasForeignKey(x => x.GymId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Member)
            .WithMany(x => x.Attendances)
            .HasForeignKey(x => x.MemberId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.MarkedByUser)
            .WithMany()
            .HasForeignKey(x => x.MarkedByUserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}