using webEscuela.Application.Dto;
using webEscuela.Domain.Entities;

namespace webEscuela.Application.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    Task<Student> CreateAsync(RegisterStudentRequest dto);
    Task<bool> UpdateAsync(int id, StudentUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}