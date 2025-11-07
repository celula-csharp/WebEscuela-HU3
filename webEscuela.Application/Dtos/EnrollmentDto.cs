using webEscuela.Domain.Entities;

namespace webEscuela.Application.Dtos;

public class EnrollmentDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public double Grade { get; set; }
    public DateTime EnrollmentDate { get; set; }
    
}

// create 
public class EnrollmentCreateDto
{
    
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public double Grade { get; set; }
    public DateTime EnrollmentDate { get; set; }
    
}

public class EnrollmentUpdateDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public double Grade { get; set; }

}