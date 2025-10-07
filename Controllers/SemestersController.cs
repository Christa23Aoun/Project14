using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Project14.Models;

namespace Project14.Controllers
{
    public class SemestersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SemestersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Semesters
        public async Task<IActionResult> Index()
        {
            var semesters = await _context.Semesters
                .Include(s => s.AcademicYear)
                .AsNoTracking()
                .ToListAsync();
            return View(semesters);
        }

        // GET: Semesters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var semester = await _context.Semesters
                .Include(s => s.AcademicYear)
                .FirstOrDefaultAsync(m => m.SemesterID == id);

            if (semester == null) return NotFound();
            return View(semester);
        }

        // GET: Semesters/Create
        public IActionResult Create()
        {
            ViewBag.AcademicYearID = new SelectList(_context.AcademicYears, "AcademicYearID", "Name");
            return View();
        }

        // POST: Semesters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Semester semester)
        {
            if (ModelState.IsValid)
            {
                _context.Add(semester);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "Name", semester.AcademicYearID);
            return View(semester);
        }

        // GET: Semesters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var semester = await _context.Semesters.FindAsync(id);
            if (semester == null) return NotFound();

            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "Name", semester.AcademicYearID);
            return View(semester);
        }

        // POST: Semesters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Semester semester)
        {
            if (id != semester.SemesterID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(semester);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SemesterExists(semester.SemesterID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "Name", semester.AcademicYearID);
            return View(semester);
        }

        // GET: Semesters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var semester = await _context.Semesters
                .Include(s => s.AcademicYear)
                .FirstOrDefaultAsync(m => m.SemesterID == id);

            if (semester == null) return NotFound();
            return View(semester);
        }

        // POST: Semesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var semester = await _context.Semesters.FindAsync(id);
            if (semester != null)
            {
                _context.Semesters.Remove(semester);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SemesterExists(int id) => _context.Semesters.Any(e => e.SemesterID == id);
    }
}
