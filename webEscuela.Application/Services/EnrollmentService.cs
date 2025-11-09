using webEscuela.Application.Dtos;
using webEscuela.Application.Interfaces.Services;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;

namespace webEscuela.Application.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmenRepository;

    public EnrollmentService(IEnrollmentRepository enrollmenRepository)
    {
        _enrollmenRepository = enrollmenRepository;
    }
    
    //__________________________________
    // funcion para modificar los dtos 
    public EnrollmentDto MapConvert(Enrollment enrollment)
    {
        return new EnrollmentDto
        {

            StudentId = enrollment.StudentId,
            CourseId = enrollment.CourseId,
            Grade = enrollment.Grade,
            EnrollmentDate = enrollment.EnrollmentDate
        };
    }
    
    
    public async Task<EnrollmentDto> CreateEnrollmentAsync(EnrollmentCreateDto enrollment)
    {
        var Enrollment = new Enrollment
        {
            StudentId = enrollment.StudentId,
            CourseId = enrollment.CourseId,
            Grade = enrollment.Grade,
            EnrollmentDate = enrollment.EnrollmentDate
            
        };
        var result = await _enrollmenRepository.CreateEnrollmentAsync(Enrollment);
        return MapConvert(result);
    }

    public async Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentAsync()
    {
        var enrollme = await _enrollmenRepository.GetAllEnrollmentAsync();
        return enrollme.Select(MapConvert);
    }

    public async Task<EnrollmentDto> GetEnrollmentByIdAsync(int id)
    {
        var enroll = await _enrollmenRepository.GetEnrollmentByIdAsync(id);
        return MapConvert(enroll);
    }

    public async Task<EnrollmentDto> GetDocumentEnrollmentAsyn(int id)
    {
        var enrollme = await _enrollmenRepository.GetDocumentEnrollmentAsync(id);
        return MapConvert(enrollme);
    }

    public  async Task<EnrollmentDto> UpdateEnrollmentAsync(int id, EnrollmentUpdateDto enrollmentDto)
    {
        var enrollmenUPDATE = new Enrollment
        {
            Id = enrollmentDto.Id,
            Grade = enrollmentDto.Grade,
            CourseId = enrollmentDto.CourseId,
            StudentId = enrollmentDto.StudentId
        };
        var updateEn = await _enrollmenRepository.UpdateEnrollmentAsync(id, enrollmenUPDATE);
        return MapConvert(updateEn);
    }

    public async Task<bool> DeleteEnrollmentAsync(int id)
    {
        return await _enrollmenRepository.DeleteEnrollmentAsync(id);

    }
}