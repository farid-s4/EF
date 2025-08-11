using EFCoreLoadings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLoadings.Configurations;

public class EnrollmentsCfg : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(r => new { r.CourseId, r.StudentId });
        builder.HasOne(ur => ur.Course).WithMany(c => c.Enrollments);
        builder.HasOne(ur => ur.Student).WithMany(s => s.Enrollments);
    }
}