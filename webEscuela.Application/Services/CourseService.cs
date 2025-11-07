using webEscuela.Application.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;

namespace webEscuela.Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    // ------------------------------------------------

    // Get By Id:
    public async Task<Course> GetByIdAsync_(int id)
    {
        return await _courseRepository.GetByIdAsync(id);
    }

    
    // Get All:
    public async Task<IEnumerable<Course>> GetAllAsync_()
    {
        return await _courseRepository.GetAllAsync();
    }

    
    // Create:
    public async Task<Course> CreateAsync_(Course course)
    {
        return await _courseRepository.CreateAsync(course);
    }

    
    // Update:
    public async Task<bool> UpdateAsync_(Course course)
    {
        var existing = await _courseRepository.GetByIdAsync(course.Id);

        if (existing == null)
            return false;

        await _courseRepository.UpdateAsync(course);
        return true;
    }

    
    // Delete:
    public async Task<bool> DeleteAsync_(int id)
    {
        var existing = await _courseRepository.GetByIdAsync(id);

        if (existing == null)
            return false;

        return await _courseRepository.DeleteAsync(id);
    }
}