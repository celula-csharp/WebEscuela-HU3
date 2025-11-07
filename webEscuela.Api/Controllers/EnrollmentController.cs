using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webEscuela.Application.Dtos;
using webEscuela.Application.Interfaces.Services;

namespace webEscuela.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    
    [HttpPost]
    public async Task<ActionResult<EnrollmentDto>> create(EnrollmentCreateDto enrollmentDto)
    {
        var result = await _enrollmentService.CreateEnrollmentAsync(enrollmentDto);
        return Ok(result);

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnrollmentDto>>> GetAll()
    {
        var result = await _enrollmentService.GetAllEnrollmentAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EnrollmentDto>> getById(int id)
    {
        var result = await _enrollmentService.GetEnrollmentByIdAsync(id);
        return Ok(result);
    }
    
    [HttpGet("user/{id:int}")]
    public async Task<ActionResult<EnrollmentDto>> getByStudentId(int id)
    {
        var result = await _enrollmentService.GetDocumentEnrollmentAsyn(id);
        return Ok(result);
    }

    [HttpDelete("id")]
    public async Task<ActionResult<EnrollmentDto>> Delete(int id)
    {
        var result = await _enrollmentService.DeleteEnrollmentAsync(id);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EnrollmentDto>> Update(int id, EnrollmentUpdateDto enrollmentUpdateDto)
    {
        var result = await _enrollmentService.UpdateEnrollmentAsync(id, enrollmentUpdateDto);
        return Ok(result);
    }
}