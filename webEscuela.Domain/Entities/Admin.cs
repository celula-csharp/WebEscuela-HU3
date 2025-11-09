namespace webEscuela.Domain.Entities;

public class Admin
{
    // public int Id { get; set; }
    // public string AdminCode { get; set; }
    // public string UserName { get; set; }
    // public string Password { get; set; }
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}