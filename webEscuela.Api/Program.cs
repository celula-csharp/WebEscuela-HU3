using webEscuela.Application.Interfaces;
using webEscuela.Application.Services;
using webEscuela.Domain.Interfaces;
using webEscuela.Infrastructure.Data.Repositories;
using webEscuela.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Database Dependency Injection:
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
