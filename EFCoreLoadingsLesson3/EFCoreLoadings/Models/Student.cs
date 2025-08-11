namespace EFCoreLoadings.Models;

public class Student
{
    public string Id { get; set; } =  Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<ExamResult> ExamResults { get; set; }
    public StudentProfile StudentProfile { get; set; }
}