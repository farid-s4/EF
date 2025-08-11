namespace EFCoreLoadings.Models;

public class Department
{
    public string Id { get; set; } =  Guid.NewGuid().ToString();
    public string Name { get; set; }
    public int Budget { get; set; }
    
    public ICollection<Course> Courses { get; set; }
    
    public ICollection<Instructor>  Instructors { get; set; }
}