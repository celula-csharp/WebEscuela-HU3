using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;
using webEscuela.Infrastructure.Data;

namespace webEscuela.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<User?> GetByEmailAsync(string email) => _context.Users.FirstOrDefaultAsync(x => x.Email == email);
}