namespace webEscuela.Domain.Entities;

public class Teacher : User
{
    public int Id { get; set; }
    public string Specialization { get; set; }
    
    // Relation with other tables:
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}