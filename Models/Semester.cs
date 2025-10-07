using Project14.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Semester
{
    public int SemesterID { get; set; }

    [Required]
    [ForeignKey(nameof(AcademicYear))]
    public int AcademicYearID { get; set; }
    public AcademicYear AcademicYear { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; } // "Fall"

    public int SemesterNb { get; set; } // 1 or 2

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Course> Courses { get; set; }
}
