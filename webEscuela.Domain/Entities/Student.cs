namespace webEscuela.Domain.Entities;

public class Student : User
{
    public DateTime StartDate { get; set; }
    public string Career { get; set; } = string.Empty;
    public bool Status { get; set; }
    
    // Relation with other tables:
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}