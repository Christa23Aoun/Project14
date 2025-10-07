using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Project14.Models;

namespace Project14.Controllers
{
    public class AcademicYearsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcademicYearsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AcademicYears
        public async Task<IActionResult> Index()
        {
            var list = await _context.AcademicYears
                .AsNoTracking()
                .ToListAsync();
            return View(list);
        }

        // GET: AcademicYears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var academicYear = await _context.AcademicYears
                .FirstOrDefaultAsync(m => m.AcademicYearID == id);
            if (academicYear == null) return NotFound();

            return View(academicYear);
        }

        // GET: AcademicYears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicYears/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicYear);
        }

        // GET: AcademicYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var academicYear = await _context.AcademicYears.FindAsync(id);
            if (academicYear == null) return NotFound();
            return View(academicYear);
        }

        // POST: AcademicYears/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AcademicYear academicYear)
        {
            if (id != academicYear.AcademicYearID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicYearExists(academicYear.AcademicYearID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(academicYear);
        }

        // GET: AcademicYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var academicYear = await _context.AcademicYears
                .FirstOrDefaultAsync(m => m.AcademicYearID == id);
            if (academicYear == null) return NotFound();

            return View(academicYear);
        }

        // POST: AcademicYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicYear = await _context.AcademicYears.FindAsync(id);
            if (academicYear != null)
            {
                _context.AcademicYears.Remove(academicYear);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicYearExists(int id)
        {
            return _context.AcademicYears.Any(e => e.AcademicYearID == id);
        }
    }
}
