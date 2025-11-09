using Moq;
using webEscuela.Application.Dtos;
using webEscuela.Application.Services;
using webEscuela.Domain.Interfaces;
using webEscuela.Infrastructure.Repositories;

namespace webEscuela.Test.Unit;

public class EnrollmentServicesTest
{
    
    // se crea el archivo .Test
    // se relaciona a .Api, .Aplication, .Domain
    // se agrega a la solucion
    
    // se instalan estas dependencias :
    // dotnet add package xunit
    //dotnet add package Microsoft.NET.Test.Sdk
    // dotnet add package xunit.runner.visualstudio
    // dotnet add package Moq
    
    // necesito 2 cosas : servicios 

    private readonly Mock<IEnrollmentRepository> _enrollmetRepository;
    private readonly EnrollmentService _enrollmentService;

    public EnrollmentServicesTest()
    {
        _enrollmetRepository = new Mock<IEnrollmentRepository>();
        _enrollmentService = new EnrollmentService(_enrollmetRepository.Object);
    }

    // "studentId": 0,
    // "courseId": 0,
    // "grade": 0,
    // "enrollmentDate": "2025-11-07T01:22:20.273Z"

    
    // StudentId = enrollment.StudentId,
    // CourseId = enrollment.CourseId,
    // Grade = enrollment.Grade,
    // EnrollmentDate = enrollment.EnrollmentDate
    [Fact]
    public async Task ReturnEnrollmentDtoWhenCreateOK()
    {
        var enrollmet = new EnrollmentCreateDto
        {
         StudentId   = 1,
         CourseId = 1,
         Grade = 69,
         EnrollmentDate = DateTime.Parse("2025-11-07T01:22:20.273Z")
        };
        
        
        // El objeto que el repositorio debería devolver
        var enrollmentEntity = new Enrollment
        {
            StudentId = 1,
            CourseId = 1,
            Grade = 69,
            EnrollmentDate = enrollmentCreateDto.EnrollmentDate
        };
        
        
        
        
        
        // 
        _enrollmetRepository.Setup(s => s.CreateEnrollmentAsync(enrollmet)).ReturnsAsync(enrollmet);
        
        var result = await _enrollmentService.CreateEnrollmentAsync(enrollmet);
    }
    
}