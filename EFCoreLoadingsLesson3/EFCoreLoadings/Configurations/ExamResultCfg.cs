using EFCoreLoadings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLoadings.Configurations;

public class ExamResultCfg : IEntityTypeConfiguration<ExamResult>
{
    public void Configure(EntityTypeBuilder<ExamResult> builder)
    {
        builder.HasKey(x => new { x.CourseId, x.StudentId });
        builder.HasOne(x => x.Student).WithMany(s => s.ExamResults);
        builder.HasOne(x => x.Course).WithMany(c => c.ExamResults);
    }
}