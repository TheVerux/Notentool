using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notentool;
using Notentool.Models.Entities;

namespace Notentool.Controllers
{
    [Authorize]
    [Route("moduls/{modulId}/[controller]")]
    public class GradesController : Controller
    {
        private readonly Context _context;

        public GradesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int modulId)
        {
            var modul = await _context.Moduls.FirstOrDefaultAsync(m => m.ModulID == modulId);

            var grades = await _context.Grades.Where(g => g.Modul.ModulID == modulId).ToListAsync();
            return View(grades);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int modulId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .FirstOrDefaultAsync(m => m.GradeID == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create(int modulId)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public async Task<IActionResult> Create(int modulId, [Bind("GradeID,Name,Note,Gewichtung")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                var modul = await _context.Moduls.FirstOrDefaultAsync(m => m.ModulID == modulId);
                grade.Modul = modul;
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { modulId });
            }
            return View(grade);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int modulId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int modulId, int id, [Bind("GradeID,Name,Note,Gewichtung")] Grade grade)
        {
            if (id != grade.GradeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (grade.Modul == null)
                    {
                        var modul = await _context.Moduls.FirstOrDefaultAsync(m => m.ModulID == modulId);
                        grade.Modul = modul;
                    }
                    _context.Update(grade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeExists(grade.GradeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { modulId });
            }
            return View(grade);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int modulId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .FirstOrDefaultAsync(m => m.GradeID == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int modulId, int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { modulId });
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.GradeID == id);
        }
    }
}
