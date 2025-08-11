namespace EFCoreLoadings.Models;

public class Instructor
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public DateTime HireDate { get; set; }
    
    public ICollection<CourseAssignment> CourseAssignments { get; set; }
    public OfficeAssignment OfficeAssignment { get; set; }
    
    public string DepartmentId { get; set; }
    public Department Department { get; set; }
}