namespace EFCoreLoadings.Models;

public class Course
{
    public string Id { get; set; }  = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public int Credit { get; set; }
    
    public string DepartmentId { get; set; }
    public Department Department { get; set; }

    public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    
    public Exam Exam { get; set; }
    public ICollection <CourseAssignment> CourseAssignments { get; set; }
    public ICollection <Enrollment> Enrollments { get; set; }
    public ICollection<ExamResult> ExamResults { get; set; }
    
    
}