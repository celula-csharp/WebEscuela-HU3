using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;
using webEscuela.Infrastructure.Data;

namespace webEscuela.Infrastructure.Repositories;

public class EnrollmentRepository : IEnrollmentRepository
{
    // db contest para la db 
    private static AppDbContext _appDbContext;

    public EnrollmentRepository(AppDbContext context)
    {
        _appDbContext = context;
    }
    
    // 
    public async Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment)
    {
        try
        {
            var enrollnew = await _appDbContext.Enrollments.FindAsync(enrollment.Id);
            if (enrollnew != null) return null;

            await _appDbContext.Enrollments.AddAsync(enrollment);
            await _appDbContext.SaveChangesAsync();
            return enrollment;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Enrollment>> GetAllEnrollmentAsync()
    {
        try
        {
            return await _appDbContext.Enrollments.ToListAsync();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
    {
        try
        {
            var enroll = await _appDbContext.Enrollments.FindAsync(id);
            return enroll;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    // buscar por docuemto 
    public async Task<Enrollment> GetDocumentEnrollmentAsync(int id)
    {
        try
        {
            var document = await _appDbContext.Enrollments.FirstAsync(d => d.Student.Id == id);
            return document;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    /// <summary>
    /// Actualiza los datos de una matrícula existente en la base de datos.
    /// </summary>
    /// <param name="id">Identificador único del registro de matrícula (Enrollment) a modificar.</param>
    /// <param name="grade">Nueva calificación (nota) del estudiante.</param>
    /// <param name="courseId">Identificador del curso asociado a la matrícula.</param>
    /// <param name="studentId">Identificador del estudiante asociado a la matrícula.</param>
    /// <returns>
    /// Retorna el objeto <see cref="Enrollment"/> actualizado con los nuevos datos.
    /// </returns>
    /// <exception cref="Exception">
    /// Se lanza cuando no se encuentra el registro o ocurre un error al guardar los cambios.
    /// </exception>
    /// 
    public async Task<Enrollment> UpdateEnrollmentAsync(int id, Enrollment enrollment)
    {
        try
        {
            var exitId = await _appDbContext.Enrollments.FindAsync(id);
            if (exitId == null) return null;
            
            // update 

            exitId.Grade = enrollment.Grade;
            exitId.CourseId = enrollment.CourseId;
            exitId.StudentId = enrollment.StudentId;
            await _appDbContext.SaveChangesAsync();

            return exitId;

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

  

    
    
    public async Task<bool> DeleteEnrollmentAsync(int id)
    {
        try
        {
            var deleteId = await _appDbContext.Enrollments.FindAsync(id);
            if (deleteId == null) return false;

            _appDbContext.Remove(deleteId);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}