using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using webEscuela.Application.Dto;
using webEscuela.Application.Dtos.Teacher;
using webEscuela.Application.Interfaces; 

namespace webEscuela.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeachersController(ITeacherService service)
        {
            _service = service;
        }

        // GET: api/teachers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _service.GetAllTeachersAsync();
            return Ok(teachers);
        }

        // GET: api/teachers/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _service.GetTeachersByIdAsync(id);
            if (teacher == null) 
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        // POST: api/teachers
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherCreateDto dto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var teacher = await _service.CreateAsync(dto);
            
            return CreatedAtAction(nameof(GetById), new { id = teacher.Id },
                new { id = teacher.Id, message = "Profesor creado correctamente." });
        }

        // PUT: api/teachers/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TeacherUpdateDto dto)
        {
            var updated = await _service.UpdateTeachersAsync(id, dto);
            if (!updated) 
            {
                return NotFound();
            }

            return Ok(new { message = "Profesor actualizado correctamente." });
        }

        // DELETE: api/teachers/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteTeachersAsync(id);
            if (!deleted) 
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}