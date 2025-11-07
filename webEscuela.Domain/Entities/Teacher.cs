namespace webEscuela.Domain.Entities;

public class Teacher : User
{
    public string Specialization { get; set; } = string.Empty;
    
    // Relation with other tables:
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}