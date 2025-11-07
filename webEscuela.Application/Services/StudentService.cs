using webEscuela.Application.Dto;
using webEscuela.Application.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;

namespace webEscuela.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public Task<Student> CreateAsync(RegisterStudentRequest dto)
    {
        throw new NotImplementedException();
    }


    public async Task<bool> UpdateAsync(int id, StudentUpdateDto dto)
    {
        var student = await _repository.GetByIdAsync(id);
        if (student == null) return false;

        if (dto.Career != null) student.Career = dto.Career;
        if (dto.StartDate.HasValue) student.StartDate = dto.StartDate.Value;
        if (dto.Status.HasValue) student.Status = dto.Status.Value;

        await _repository.UpdateAsync(student);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var student = await _repository.GetByIdAsync(id);
        if (student == null) return false;

        await _repository.DeleteAsync(student);
        return true;
    }
}