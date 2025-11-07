using webEscuela.Domain.Entities;

namespace webEscuela.Application.Interfaces;

public interface IAdminService
{
    Task<bool> RegisterAdmin(string email, string password);
}