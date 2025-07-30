namespace Lesson2.Models;

public class Course
{
    public string Id { get; set; } =  Guid.NewGuid().ToString();
    public string Tittle { get; set; }
    public int Credits { get; set; }
    
    public ICollection<StudentCourse> StudentsCourses { get; set; }
}