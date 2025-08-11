namespace EFCoreLoadings.Models;

public class CourseAssignment
{
    public int Id { get; set; }
    public string CourseId { get; set; }
    public string InstructorId { get; set; }
    
    public Instructor Instructor { get; set; }
    public Course Course { get; set; }
}