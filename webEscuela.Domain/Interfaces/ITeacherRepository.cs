using webEscuela.Domain.Entities;

namespace webEscuela.Domain.Interfaces;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetAllAsync();
    Task<Teacher?> GetByIdAsync(int id);
    Task<Teacher> AddAsync(Teacher student);
    Task UpdateAsync(Teacher student);
    Task DeleteAsync(Teacher student);
}