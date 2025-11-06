namespace webEscuela.Application.Dto;

public class CourseCreateUpdateDto
{
    public string CourseName { get; set; }
    public string Code { get; set; }
    public int TeacherId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}