using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webEscuela.Application.Dto;
using webEscuela.Application.Interfaces;

namespace webEscuela.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/teacher")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _service;

    public TeacherController(ITeacherService service)
    {
        _service = service;
    }

    // GET /api/teacher
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teachers = await _service.GetAllAsync();
        return Ok(teachers);
    }

    // GET /api/teacher/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _service.GetByIdAsync(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    // POST /api/teacher
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StudentCreateDto dto)
    {
        return Ok();
        // if (!ModelState.IsValid) return BadRequest(ModelState);
        //
        // var student = await _service.CreateAsync(dto);
        // return CreatedAtAction(nameof(GetById), new { id = student.Id },
        //     new { id = student.Id, message = "Estudiante creado correctamente." });
    }

    // PUT /api/teacher/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] TeacherUpdateDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();

        return Ok(new { message = "Estudiante actualizado correctamente." });
    }

    // DELETE /api/teacher/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}