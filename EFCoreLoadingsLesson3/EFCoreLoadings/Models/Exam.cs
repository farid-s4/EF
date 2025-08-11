namespace EFCoreLoadings.Models;

public class Exam
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CourseId { get; set; }
    public Course Course { get; set; }
    public DateTime Date { get; set; }
    public decimal MaxScore { get; set; }
    
    public ICollection<ExamResult> ExamResults { get; set; }
}