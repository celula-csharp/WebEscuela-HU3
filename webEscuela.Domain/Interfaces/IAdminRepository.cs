using webEscuela.Domain.Entities;

namespace webEscuela.Domain.Interfaces;

public interface IAdminRepository
{
    Task<Admin?> GetByEmailAsync(string email);
    Task AddAsync(Admin admin);
}