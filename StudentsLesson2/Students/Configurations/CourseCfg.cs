namespace Lesson2.Configurations;
using Lesson2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class CourseCfg : IEntityTypeConfiguration<Course>
{
    [Obsolete("Obsolete")]
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(u => u.Id); // Primary Key

        var tittle = builder.Property(t => t.Tittle);
        tittle.IsRequired();

        var credits = builder.Property(c => c.Credits);
        credits.IsRequired();
        
        builder.HasCheckConstraint("CK_Course_Credits_Positive", "[Credits] > 0");
    }
}
