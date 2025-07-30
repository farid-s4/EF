namespace Lesson2.Models;

public class Student
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    
    public ICollection<StudentCourse> StudentsCourses { get; set; }
}