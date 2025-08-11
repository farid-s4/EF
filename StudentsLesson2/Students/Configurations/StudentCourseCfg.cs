namespace Lesson2.Configurations;
using Lesson2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StudentCourseCfg :  IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.HasKey(s => new { s.CourseId, s.StudentId });
        
        builder.HasOne(ur => ur.Student).WithMany(u => u.StudentsCourses);

        builder.HasOne(ur => ur.course).WithMany(r => r.StudentsCourses);
    }
}