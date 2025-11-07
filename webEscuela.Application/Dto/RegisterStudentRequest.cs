namespace webEscuela.Application.Dto;

public record RegisterStudentRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
);