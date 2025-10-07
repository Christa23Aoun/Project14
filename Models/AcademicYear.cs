using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Project14.Models;
public class AcademicYear
{
    public int AcademicYearID { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; }    // "2024-2025"

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Semester> Semesters { get; set; }
}
