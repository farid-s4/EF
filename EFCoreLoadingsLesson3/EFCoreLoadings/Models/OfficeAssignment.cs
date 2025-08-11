
namespace EFCoreLoadings.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class OfficeAssignment
{
    public string InstructorId { get; set; }
    public string OfficeLocation { get; set; }
    public Instructor Instructor { get; set; }
}
