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
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Student>().ToTable("students");
        modelBuilder.Entity<Teacher>().ToTable("teachers");
        modelBuilder.Entity<Admin>().ToTable("admins");
        
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
            .HasIndex(c => c.Id)
            .IsUnique();
        
        modelBuilder.Entity<Admin>()
            .HasIndex(c => c.Email)
            .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }


    // To create tables on the DB:
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Admin> Admins { get; set; }
    
}