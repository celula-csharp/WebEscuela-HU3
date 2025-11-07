using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;
using webEscuela.Infrastructure.Data;

namespace webEscuela.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;
    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }
    // -------------------------------------------------

    // Get By Id
    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _context.courses_tb.FindAsync(id);
    }

    
    // Get All:
    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.courses_tb.ToListAsync();
    }

    
    // Create:
    public async Task<Course> CreateAsync(Course course)
    {
        _context.courses_tb.Add(course);
        await _context.SaveChangesAsync();
        return course;
    }

    
    // Update:
    public async Task<Course?> UpdateAsync(Course course)
    {
        var exist = await _context.courses_tb.FindAsync(course.Id);

        if (exist == null)
            return null;

        exist.CourseName = course.CourseName;
        exist.Code = course.Code;
        exist.TeacherId = course.TeacherId;
        exist.StartDate = course.StartDate;
        exist.EndDate = course.EndDate;

        await _context.SaveChangesAsync();
        
        return course;
    }

    
    // Delete:
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _context.courses_tb.FindAsync(id);

        if (toDelete == null)
            return false;

        _context.courses_tb.Remove(toDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}