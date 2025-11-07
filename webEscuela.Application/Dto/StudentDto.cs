namespace webEscuela.Application.Dto;

public class StudentCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Career { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public bool? Status { get; set; }
}

public class StudentUpdateDto
{
    public string? Career { get; set; }
    public DateTime? StartDate { get; set; }
    public bool? Status { get; set; }
}