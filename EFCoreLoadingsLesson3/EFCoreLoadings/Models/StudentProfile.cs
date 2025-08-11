using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreLoadings.Models;

public class StudentProfile
{
    public string StudentId { get; set; }
    public Student Student { get; set; }
    public string Adress { get; set; }
    
}