using EFCoreLoadings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLoadings.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class CourseAssignmentCfg  : IEntityTypeConfiguration<CourseAssignment>
{
    public void Configure(EntityTypeBuilder<CourseAssignment> builder)
    {
        builder.HasKey(r => new { r.CourseId, r.InstructorId });
        builder.HasOne(ur => ur.Course).WithMany(c => c.CourseAssignments);
        builder.HasOne(ur => ur.Instructor).WithMany(i => i.CourseAssignments);
    }
}