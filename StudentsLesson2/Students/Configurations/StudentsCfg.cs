namespace Lesson2.Configurations;
using Lesson2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class StudentsCfg : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(u => u.Id); // Primary Key 


        var name = builder.Property(u => u.Name);
        name.IsRequired();
        name.HasMaxLength(30);

        var email = builder.Property(u => u.Email);
        email.IsRequired();
        email.HasMaxLength(254);

        var  birthDate = builder.Property(u => u.BirthDate);
        birthDate.IsRequired();
    }
}