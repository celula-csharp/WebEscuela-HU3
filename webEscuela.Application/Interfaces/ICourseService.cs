using webEscuela.Domain.Entities;

namespace webEscuela.Application.Interfaces;

public interface ICourseService
{
    Task<Course> GetByIdAsync_(int id);
    Task<IEnumerable<Course>> GetAllAsync_();
    Task<Course> CreateAsync_(Course client);
    Task<bool> UpdateAsync_(Course client);
    Task<bool> DeleteAsync_(int id);
}