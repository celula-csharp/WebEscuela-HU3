using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using webEscuela.Application.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;

namespace webEscuela.Application.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repo;
    private readonly IConfiguration _config;

    public AdminService(IAdminRepository repo, IConfiguration config)
    {
        _repo = repo;
        _config = config;
    }

    public async Task<bool> RegisterAdmin(string email, string password)
    {
        // Verificar si ya existe
        var exists = await _repo.GetByEmailAsync(email);
        if (exists != null) return false;

        var admin = new Admin
        {
            Email = email,
            Password = BCrypt.Net.BCrypt.HashPassword(password)
        };

        // Guardar
        await _repo.AddAsync(admin);
        return true;
    }

    public Task AddAsync(Admin admin)
    {
        throw new NotImplementedException();
    }
}