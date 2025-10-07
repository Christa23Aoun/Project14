using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class CoursesController : Controller
{
    private readonly ApplicationDbContext _context;
    public CoursesController(ApplicationDbContext context) { _context = context; }

    public async Task<IActionResult> Index()
    {
        var courses = await _context.Courses
            .Include(c => c.Department)
            .Include(c => c.Semester)
            .ToListAsync();
        return View(courses);
    }

    public IActionResult Create()
    {
        ViewData["Departments"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName");
        ViewData["Semesters"] = new SelectList(_context.Semesters, "SemesterID", "Name");
        // Teacher dropdown provided once Dev1 supplies Users table
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Departments"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", course.DepartmentID);
        ViewData["Semesters"] = new SelectList(_context.Semesters, "SemesterID", "Name", course.SemesterID);
        return View(course);
    }

    // Edit, Details, Delete similar — scaffolder will auto-generate them.
}
