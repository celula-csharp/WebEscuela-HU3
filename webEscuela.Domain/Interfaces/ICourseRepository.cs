using webEscuela.Domain.Entities;

namespace webEscuela.Domain.Interfaces;

public interface ICourseRepository
{
    Task<Course?> GetByIdAsync(int id);
    Task<IEnumerable<Course>> GetAllAsync();
    Task<Course> CreateAsync(Course course);
    Task<Course?> UpdateAsync(Course course);
    Task<bool> DeleteAsync(int id);
}