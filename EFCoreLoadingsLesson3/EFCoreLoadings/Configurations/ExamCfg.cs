using EFCoreLoadings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLoadings.Configurations;

public class ExamCfg :  IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Course)
            .WithOne(c => c.Exam)
            .HasForeignKey<Exam>(e => e.CourseId);
    }
}