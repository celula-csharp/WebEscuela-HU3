namespace webEscuela.Application.Dto;

public class TeacherCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Career { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public bool? Status { get; set; }
}

public class TeacherUpdateDto
{
    public string? Specialization { get; set; }
}