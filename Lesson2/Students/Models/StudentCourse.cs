namespace Lesson2.Models;

public class StudentCourse
{
    public string CourseId { get; set; }
    public string StudentId { get; set; }
    
    public virtual Student Student { get; set; }
    public virtual Course course { get; set; }
}