using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Project14.Models;
public class Department
{
    public int DepartmentID { get; set; }

    [Required, StringLength(150)]
    public string DepartmentName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Course> Courses { get; set; }
}
