using webEscuela.Domain.Entities;

namespace webEscuela.Domain.Interfaces;

// + Create():
// + GetAll():
// + Update():
// + Delete():
// + getDocuemnt();
//Task<T> GetIdAsync(int id);

// contratos
public interface IEnrollmentRepository
{
    
    Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment);

    Task<IEnumerable<Enrollment>> GetAllEnrollmentAsync();
    Task<Enrollment> GetEnrollmentByIdAsync(int id);
    Task<Enrollment> GetDocumentEnrollmentAsync(int id);

    Task<Enrollment> UpdateEnrollmentAsync(int id, Enrollment enrollment);

    Task<bool> DeleteEnrollmentAsync(int id);
}