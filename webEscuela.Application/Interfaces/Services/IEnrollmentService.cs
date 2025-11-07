using webEscuela.Application.Dtos;

namespace webEscuela.Application.Interfaces.Services;

public interface IEnrollmentService
{
        
    Task<EnrollmentDto> CreateEnrollmentAsync(EnrollmentCreateDto enrollmen);

    Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentAsync();

    Task<EnrollmentDto> GetDocumentEnrollmentAsyn(string id);

    Task<EnrollmentDto> UpdateEnrollmentAsync(int id, EnrollmentUpdateDto enrollmentDto);

    Task<bool> DeleteEnrollmentAsync(int id);
}
