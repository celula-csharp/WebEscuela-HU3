namespace webEscuela.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string Code { get; set; }
    public int TeacherId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    // Relations 1:N
    public Teacher Teacher { get; set; }
}