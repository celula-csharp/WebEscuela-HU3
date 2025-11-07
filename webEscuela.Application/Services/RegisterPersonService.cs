using webEscuela.Application.Dto;
using webEscuela.Application.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;

namespace webEscuela.Application.Services;

public class RegisterPersonService : IRegisterPersonService
{
    private readonly IStudentRepository _studentRepo;
    private readonly ITeacherRepository _teacherRepo;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterPersonService(IStudentRepository studentRepo, ITeacherRepository teacherRepo, IPasswordHasher passwordHasher)
    {
        _studentRepo = studentRepo;
        _teacherRepo = teacherRepo;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Student> RegisterStudentAsync(RegisterPersonRequest request)
    {
        var student = new Student
        {
            Name = request.Name,
            LastName = request.LastName,
            DocNumber = request.DocNumber,
            Email = request.Email,
            Phone = request.Phone,
            UserName = request.UserName.ToLower(),
            Password = _passwordHasher.Hash(request.Password),
            Code = Guid.NewGuid().ToString("N")[..8],
            Role = Role.student,
            Career = request.Career,
            StartDate = request.StartDate ?? DateTime.UtcNow,
            Status = true
        };
        
        await _studentRepo.AddAsync(student);
        return student;
    }

    public async Task<Teacher> RegisterTeacherAsync(RegisterPersonRequest request)
    {
        var teacher = new Teacher
        {
            Name = request.Name,
            LastName = request.LastName,
            DocNumber = request.DocNumber,
            Email = request.Email,
            Phone = request.Phone,
            UserName = request.UserName.ToLower(),
            Password = _passwordHasher.Hash(request.Password),
            Code = Guid.NewGuid().ToString("N")[..8],
            Role = Role.teacher,
            Specialization = request.Specialization ?? "Sin especialización"
        };

        await _teacherRepo.AddAsync(teacher);
        return teacher;
    }
}