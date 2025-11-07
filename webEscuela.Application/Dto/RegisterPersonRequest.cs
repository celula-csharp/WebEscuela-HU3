namespace webEscuela.Application.Dto;

public class RegisterPersonRequest
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string DocNumber { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    // Solo para Student
    public string? Career { get; set; }
    public DateTime? StartDate { get; set; }
    
    // Solo para teacher
    public string? Specialization { get; set; }
}