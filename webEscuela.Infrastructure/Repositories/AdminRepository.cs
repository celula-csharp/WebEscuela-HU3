using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;
using webEscuela.Infrastructure.Data;

namespace webEscuela.Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(Admin admin)
    {
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();
    }
    
    public Task<Admin?> GetByEmailAsync(string email) => _context.Admins.FirstOrDefaultAsync(x => x.Email == email);
}