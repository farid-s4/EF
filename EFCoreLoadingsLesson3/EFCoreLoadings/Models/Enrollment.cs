namespace EFCoreLoadings.Models;

public class Enrollment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CourseId { get; set; }
    public string StudentId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    
    public virtual Course Course { get; set; }
    public virtual Student Student { get; set; }
    
}