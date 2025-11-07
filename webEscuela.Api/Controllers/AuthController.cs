using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using webEscuela.Application.Auth;
using webEscuela.Application.Dto;
using webEscuela.Application.Interfaces;
using webEscuela.Application.Services;
using webEscuela.Domain.Entities;

namespace webEscuela.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly LoginService _loginService;
    private readonly IAdminService _adminService;
    private readonly IRegisterPersonService _registerPersonService;

    public AuthController(LoginService loginService, IAdminService adminService, IRegisterPersonService registerPersonService)
    {
        _loginService = loginService;
        _adminService =  adminService;
        _registerPersonService = registerPersonService;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _loginService.Login(request.Email, request.Password);
        if (token == null) return Unauthorized("Invalid credentials.");
        return Ok(new { token });
    }

    [HttpPost("register/admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminRequest request, [FromServices] IAdminService service)
    {
        var created = await service.RegisterAdmin(request.Email, request.Password);
        if (!created) return Conflict("Ya existe un admin con ese email");
        return Ok("Admin creado con éxito");
    }

    [HttpPost("register/student")]
    public async Task<IActionResult> RegisterStudent([FromBody] RegisterPersonRequest request)
    {
        var result = await _registerPersonService.RegisterStudentAsync(request);
        return Ok(result);
    } 
    
    [HttpPost("register/teacher")]
    public async Task<IActionResult> RegisterTeacher([FromBody] RegisterPersonRequest request)
    {
        var result = await _registerPersonService.RegisterTeacherAsync(request);
        return Ok(result);
    }
}

public record LoginRequest(string Email, string Password);
public record RegisterAdminRequest(string Email, string Password);
