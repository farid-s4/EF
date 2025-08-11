namespace EFCoreLoadings.Configurations;
using EFCoreLoadings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StudentProfileCfg  : IEntityTypeConfiguration<StudentProfile>
{
    public void Configure(EntityTypeBuilder<StudentProfile> builder)
    {
        builder.HasKey(o => o.StudentId);
        builder.Property(o => o.Adress)
            .HasMaxLength(100)             
            .IsRequired(false);          

        builder.HasOne(o => o.Student)
            .WithOne(i => i.StudentProfile)
            .HasForeignKey<StudentProfile>(o => o.StudentId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}