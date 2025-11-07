using webEscuela.Application.Interfaces.Services;
using webEscuela.Application.Services;
using webEscuela.Domain.Interfaces;
using webEscuela.Infrastructure.Extensions;
using webEscuela.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Database Dependency Injection:
builder.Services.AddInfrastructure(builder.Configuration);

//inyectar 
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();


builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
// Add services to the container.


var corsPolicyName = "AllowAllOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy
            .AllowAnyOrigin()   // Permite cualquier dominio
            .AllowAnyHeader()   // Permite cualquier encabezado
            .AllowAnyMethod();  // Permite GET, POST, PUT, DELETE, etc.
     
    });
});



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


// 