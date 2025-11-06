using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Entities;

namespace webEscuela.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Stablishing unique fields on the DB:
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Teachers
        modelBuilder.Entity<Teacher>()
            .HasIndex(c => c.DocNumber)
            .IsUnique();
        
        modelBuilder.Entity<Teacher>()
            .HasIndex(c => c.Email)
            .IsUnique();
        
        modelBuilder.Entity<Teacher>()
            .HasIndex(c => c.UserName)
            .IsUnique();
        
        modelBuilder.Entity<Teacher>()
            .HasIndex(c => c.Code)
            .IsUnique();
        
        //Course
        modelBuilder.Entity<Course>()
            .HasIndex(c => c.Code)
            .IsUnique();
        
        // Student
        modelBuilder.Entity<Student>()
            .HasIndex(c => c.DocNumber)
            .IsUnique();
        
        modelBuilder.Entity<Student>()
            .HasIndex(c => c.Email)
            .IsUnique();
        
        modelBuilder.Entity<Student>()
            .HasIndex(c => c.UserName)
            .IsUnique();
        
        modelBuilder.Entity<Student>()
            .HasIndex(c => c.Code)
            .IsUnique();
        
        //Admin
        modelBuilder.Entity<Admin>()
            .HasIndex(c => c.AdminCode)
            .IsUnique();
        
        modelBuilder.Entity<Admin>()
            .HasIndex(c => c.UserName)
            .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }


    // To create tables on the DB:
    public DbSet<Admin> admins_tb { get; set; }
    public DbSet<Course> courses_tb { get; set; }
    public DbSet<Enrollment> enrollments_tb { get; set; }
    public DbSet<Student> students_tb { get; set; }
    public DbSet<Teacher> teachers_tb { get; set; }
    
}