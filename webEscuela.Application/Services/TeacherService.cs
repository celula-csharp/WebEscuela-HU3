using webEscuela.Application.Dto;
using webEscuela.Application.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;

namespace webEscuela.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;

    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Teacher?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public Task<Teacher> CreateAsync(TeacherCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(int id, TeacherUpdateDto dto)
    {
        var teacher = await _repository.GetByIdAsync(id);
        if (teacher == null) return false;

        if (dto.Specialization != null) teacher.Specialization = dto.Specialization;

        await _repository.UpdateAsync(teacher);
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