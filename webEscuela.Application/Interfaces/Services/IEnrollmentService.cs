using webEscuela.Application.Dtos;

namespace webEscuela.Application.Interfaces.Services;

public interface IEnrollmentService
{
        
    Task<EnrollmentDto> CreateEnrollmentAsync(EnrollmentCreateDto enrollmen);

    Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentAsync();

    Task<EnrollmentDto> GetEnrollmentByIdAsync(int id);
    Task<EnrollmentDto> GetDocumentEnrollmentAsyn(int id);

    Task<EnrollmentDto> UpdateEnrollmentAsync(int id, EnrollmentUpdateDto enrollmentDto);

    Task<bool> DeleteEnrollmentAsync(int id);
}
