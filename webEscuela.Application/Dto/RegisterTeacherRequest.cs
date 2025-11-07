namespace webEscuela.Application.Dto;

public record RegisterTeacherRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
);