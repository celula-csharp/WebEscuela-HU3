using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;
using webEscuela.Infrastructure.Data;

namespace webEscuela.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            _context.teachers_tb.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task DeleteAsync(Teacher teacher)
        {
            _context.teachers_tb.Remove(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.teachers_tb.ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.teachers_tb.FindAsync(id);
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.teachers_tb.Update(teacher);
            await _context.SaveChangesAsync();
        }
    }
}