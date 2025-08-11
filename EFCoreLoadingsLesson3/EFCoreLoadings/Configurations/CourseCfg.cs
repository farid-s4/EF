using EFCoreLoadings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLoadings.Configurations;

public class CourseCfg  : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Title).IsRequired();
        builder.Property(r => r.Title).HasMaxLength(30);

        builder.HasOne(c => c.Department)
            .WithMany()
            .HasForeignKey("DepartmentId")
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}