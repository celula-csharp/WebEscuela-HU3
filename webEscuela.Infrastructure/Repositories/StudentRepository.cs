using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;
using webEscuela.Infrastructure.Data;

namespace webEscuela.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.students_tb.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.students_tb.FindAsync(id);
    }

    public async Task<Student> AddAsync(Student student)
    {
        _context.students_tb.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task UpdateAsync(Student student)
    {
        _context.students_tb.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Student student)
    {
        _context.students_tb.Remove(student);
        await _context.SaveChangesAsync();
    }
}