namespace webEscuela.Application.Dto;

public class StudentCreateDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Career { get; set; }
    public DateTime? StartDate { get; set; }
    public bool? Status { get; set; }
}

public class StudentUpdateDto
{
    public string? Career { get; set; }
    public DateTime? StartDate { get; set; }
    public bool? Status { get; set; }
}