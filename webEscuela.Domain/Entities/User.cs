namespace webEscuela.Domain.Entities;

public enum Role
{
    admin,
    teacher,
    student
};

public abstract class User
{
    // Properties:
    public string Name { get; set; }
    public string LastName { get; set; }
    public string DocNumber { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public string Code { get; set; }
}