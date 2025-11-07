using webEscuela.Application.Dto;
using webEscuela.Domain.Entities;

namespace webEscuela.Application.Interfaces;

public interface IRegisterPersonService
{
    Task<Student> RegisterStudentAsync(RegisterPersonRequest request);
    Task<Teacher> RegisterTeacherAsync(RegisterPersonRequest request);
}