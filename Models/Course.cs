using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;
using Project14.Models;

public class Course
{
    public int CourseID { get; set; }

    [Required, StringLength(30)]
    public string CourseCode { get; set; }

    [Required, StringLength(200)]
    public string CourseName { get; set; }

    public int CreditHours { get; set; } = 3;

    [ForeignKey(nameof(Department))]
    public int DepartmentID { get; set; }
    public Department Department { get; set; }

    // TeacherID references Users table (Dev1). Keep int FK; navigation property optional.
    public int TeacherID { get; set; }

    [ForeignKey(nameof(Semester))]
    public int SemesterID { get; set; }
    public Semester Semester { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

 //   public ICollection<Test> Tests { get; set; }     // Test entity can be defined by Dev3
    // public ICollection<StudentCourse> StudentCourses { get; set; } // StudentCourse defined by Dev3
}
