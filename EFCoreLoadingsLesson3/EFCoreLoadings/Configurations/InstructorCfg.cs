using EFCoreLoadings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLoadings.Configurations;

public class InstructorCfg : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(r => r.Name).IsRequired();
        builder.Property(r => r.Name).HasMaxLength(30);
        
    }
}