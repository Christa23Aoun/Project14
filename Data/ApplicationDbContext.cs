using Microsoft.EntityFrameworkCore;
using Project14.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<AcademicYear> AcademicYears { get; set; }
    public DbSet<Semester> Semesters { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Course> Courses { get; set; }

    // If Dev1 or Dev3 adds these models, you can include them too:
    // public DbSet<User> Users { get; set; }
    // public DbSet<Test> Tests { get; set; }
    // public DbSet<StudentCourse> StudentCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>()
            .HasIndex(c => c.CourseCode)
            .IsUnique();

        // Default value for CreatedAt
        modelBuilder.Entity<AcademicYear>()
            .Property(a => a.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Semester>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Department>()
            .Property(d => d.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Course>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        // Optional: seed data
        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentID = 1, DepartmentName = "Computer Science", CreatedAt = DateTime.UtcNow },
            new Department { DepartmentID = 2, DepartmentName = "Mathematics", CreatedAt = DateTime.UtcNow }
        );

        modelBuilder.Entity<AcademicYear>().HasData(
            new AcademicYear { AcademicYearID = 1, Name = "2024-2025", StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2025, 6, 30), CreatedAt = DateTime.UtcNow }
        );

        modelBuilder.Entity<Semester>().HasData(
            new Semester { SemesterID = 1, AcademicYearID = 1, Name = "Fall", SemesterNb = 2, StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2024, 12, 20), CreatedAt = DateTime.UtcNow }
        );
    }
}
