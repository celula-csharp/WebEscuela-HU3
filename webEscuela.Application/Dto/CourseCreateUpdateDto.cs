namespace webEscuela.Application.Dto;

public class CourseCreateUpdateDto
{
    public string CourseName { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int TeacherId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}