namespace webEscuela.Domain.Entities;

public class Student : User
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public string Career { get; set; }
    public bool Status { get; set; }
    
    // Relation with other tables:
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}