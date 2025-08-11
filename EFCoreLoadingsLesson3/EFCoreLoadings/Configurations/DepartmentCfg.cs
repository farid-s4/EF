using EFCoreLoadings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLoadings.Configurations;

public class DepartmentCfg : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(r => r.Name).IsRequired();
        builder.Property(r => r.Name).HasMaxLength(30);
        builder.Property(r => r.Budget).IsRequired();
    }
}