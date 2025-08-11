namespace EFCoreLoadings.Models;

public class ExamResult
{
    public string Id { get; set; } =  Guid.NewGuid().ToString();
    public string CourseId { get; set; }
    public Course Course { get; set; }
    public string StudentId { get; set; }
    public Student Student { get; set; }
    public decimal Score { get; set; }
    
    public int ExamId { get; set; }
    
    public Exam Exam { get; set; } 
}
