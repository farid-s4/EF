namespace EFCoreLoadings.Configurations;
using EFCoreLoadings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class OfficeAssignmentCfg  : IEntityTypeConfiguration<OfficeAssignment>
{
    public void Configure(EntityTypeBuilder<OfficeAssignment> builder)
    {
        builder.HasKey(o => o.InstructorId); 

        builder.Property(o => o.OfficeLocation)
            .HasMaxLength(100)             
            .IsRequired(false);          

        builder.HasOne(o => o.Instructor)
            .WithOne(i => i.OfficeAssignment)
            .HasForeignKey<OfficeAssignment>(o => o.InstructorId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}