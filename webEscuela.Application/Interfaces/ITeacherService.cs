using webEscuela.Application.Dtos.Teacher;
using webEscuela.Domain.Entities;

namespace webEscuela.Application.Interfaces;

public interface ITeacherService
{
    Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        
    Task<Teacher?> GetTeachersByIdAsync(int id);
    
    Task<Teacher> CreateAsync(TeacherCreateDto dto);
    
    Task<bool> UpdateTeachersAsync(int id, TeacherUpdateDto updateDto);
        
    Task<bool> DeleteTeachersAsync(int id);
}