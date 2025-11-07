using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webEscuela.Application.Dto;
using webEscuela.Application.Interfaces;
using webEscuela.Domain.Entities;

namespace webEscuela.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/course")]
public class CourseController : ControllerBase
{

    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    
    // ---------------------------------------------
    
    // GET BY ID
    [HttpGet("getById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = await _courseService.GetByIdAsync_(id);

        if (course == null)
            return NotFound(new { message = $"Course with ID {id} not found." });

        return Ok(course);
    }
    
    
    // GET ALL:
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _courseService.GetAllAsync_();

        return Ok(courses);
    }

    
    // CREATE:
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CourseCreateUpdateDto courseDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var course = new Course
        {
            CourseName = courseDto.CourseName,
            Code = courseDto.Code,
            TeacherId = courseDto.TeacherId,
            StartDate = courseDto.StartDate,
            EndDate = courseDto.EndDate
        };

        var createdCourse = await _courseService.CreateAsync_(course);

        return CreatedAtAction(nameof(GetById), new { id = createdCourse.Id }, createdCourse);
    }
    
    
    
    
    // UPDATE:
    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CourseCreateUpdateDto courseDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingCourse = await _courseService.GetByIdAsync_(id);

        if (existingCourse == null)
            return NotFound(new { message = $"Register with ID {id} not found." });

        existingCourse.CourseName = courseDto.CourseName;
        existingCourse.Code = courseDto.Code;
        existingCourse.TeacherId = courseDto.TeacherId;
        existingCourse.StartDate = courseDto.StartDate;
        existingCourse.EndDate = courseDto.EndDate;

        var updated = await _courseService.UpdateAsync_(existingCourse);

        if (!updated)
            return StatusCode(500, new { message = "Error updating." });

        return NoContent();

    }
    
    
    
    // DELETE:
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var courseToDelete = await _courseService.DeleteAsync_(id);

        if (!courseToDelete)
            return NotFound(new { message = $"Register with ID {id} not founded." });

        return NoContent();
    }
}