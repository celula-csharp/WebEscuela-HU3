namespace webEscuela.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int TeacherId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    // Relations 1:N
    public Teacher Teacher { get; set; } = null!;
}