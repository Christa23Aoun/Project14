using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Project14.Models;

namespace Project14.Controllers
{
    public class ChristaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChristaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new
            {
                CoursesCount = _context.Courses.Count(),
                DepartmentsCount = _context.Departments.Count(),
                SemestersCount = _context.Semesters.Count(),
                AcademicYearsCount = _context.AcademicYears.Count(),
                ActiveCourses = _context.Courses
                    .Where(c => c.IsActive)
                    .Select(c => new { c.CourseName, c.CourseCode })
                    .ToList()
            };

            return View(model);
        }
    }
}
