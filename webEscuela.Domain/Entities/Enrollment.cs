namespace webEscuela.Domain.Entities;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public double Grade { get; set; }
    public DateTime EnrollmentDate { get; set; }
    
    // Relations 1:N
    public Student Student { get; set; }
    public Course Course { get; set; }
}