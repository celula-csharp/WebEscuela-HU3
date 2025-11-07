using webEscuela.Application.Dto;
using webEscuela.Domain.Entities;

namespace webEscuela.Application.Interfaces;

public interface ITeacherService
{
    Task<IEnumerable<Teacher>> GetAllAsync();
    Task<Teacher?> GetByIdAsync(int id);
    Task<Teacher> CreateAsync(TeacherCreateDto dto);
    Task<bool> UpdateAsync(int id, TeacherUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}