namespace webEscuela.Application.Dtos.Teacher
{
    public class TeacherCreateDto
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Code { get; set; }
    }
    
    public class TeacherUpdateDto
    {
        public string? Specialization { get; set; }
        public string? Phone { get; set; }
    }
}