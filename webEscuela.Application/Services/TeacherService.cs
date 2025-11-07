using webEscuela.Application.Dto;
using webEscuela.Application.Dtos.Teacher;
using webEscuela.Application.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;

namespace webEscuela.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _repository.GetAllAsync();
        }
        
        public async Task<Teacher?> GetTeachersByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Teacher> CreateAsync(TeacherCreateDto dto)
        {
            var teacher = new Teacher
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.UserName,
                DocNumber = dto.DocNumber,
                Code = dto.Code,
                Phone = dto.Phone,
                Specialization = dto.Specialization,
                Password = "", 
                Role = Role.teacher
            };

            return await _repository.AddAsync(teacher);
        }

        public async Task<bool> UpdateTeachersAsync(int id, TeacherUpdateDto updateDto)
        {
            var teacher = await _repository.GetByIdAsync(id);
            if (teacher == null) return false;

            if (updateDto.Specialization != null) 
                teacher.Specialization = updateDto.Specialization;
            
            if (updateDto.Phone != null)
                teacher.Phone = updateDto.Phone;

            await _repository.UpdateAsync(teacher);
            return true;
        }

        public async Task<bool> DeleteTeachersAsync(int id)
        {
            var teacher = await _repository.GetByIdAsync(id);
            if (teacher == null) return false;
            await _repository.DeleteAsync(teacher);
            return true;
        }
        
    }
}