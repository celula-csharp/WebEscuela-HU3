using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webEscuela.Application.Dto;
using webEscuela.Application.Interfaces;

namespace webEscuela.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }

    // GET /api/students
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _service.GetAllAsync();
        return Ok(students);
    }

    // GET /api/students/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _service.GetByIdAsync(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    // POST /api/students
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StudentCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var student = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = student.Id },
            new { id = student.Id, message = "Estudiante creado correctamente." });
    }

    // PUT /api/students/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] StudentUpdateDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();

        return Ok(new { message = "Estudiante actualizado correctamente." });
    }

    // DELETE /api/students/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}