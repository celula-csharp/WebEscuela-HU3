using webEscuela.Domain.Entities;

namespace webEscuela.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
}