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
    [Route("semesters/{semesterId}/[controller]")]
    public class ModulsController : Controller
    {
        private readonly Context _context;

        public ModulsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int semesterId)
        {
            var semester = await _context.Semesters.FirstOrDefaultAsync(s => s.SemesterID == semesterId);

            ViewData["Semester"] = semester;
            var moduls = await _context.Moduls.Where(m => m.Semester.SemesterID == semesterId).ToListAsync();
            return View(moduls);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int semesterId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modul = await _context.Moduls
                .FirstOrDefaultAsync(m => m.ModulID == id);
            if (modul == null)
            {
                return NotFound();
            }

            return View(modul);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create(int semesterId)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public async Task<IActionResult> Create(int semesterId, [Bind("ModulID,Name")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                var semester = await _context.Semesters.FirstOrDefaultAsync(s => s.SemesterID == semesterId);
                modul.Semester = semester;
                _context.Add(modul);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { semesterId });
            }
            return View(modul);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int semesterId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modul = await _context.Moduls.FindAsync(id);
            if (modul == null)
            {
                return NotFound();
            }
            return View(modul);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int semesterId, int id, [Bind("ModulID,Name")] Modul modul)
        {
            if (id != modul.ModulID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (modul.Semester == null)
                    {
                        var semester = await _context.Semesters.FirstOrDefaultAsync(s => s.SemesterID == semesterId);
                        modul.Semester = semester;
                    }
                    _context.Update(modul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModulExists(modul.ModulID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { semesterId });
            }
            return View(modul);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int semesterId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modul = await _context.Moduls
                .FirstOrDefaultAsync(m => m.ModulID == id);
            if (modul == null)
            {
                return NotFound();
            }

            return View(modul);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int semesterId, int id)
        {
            var modul = await _context.Moduls.FindAsync(id);
            _context.Moduls.Remove(modul);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { semesterId });
        }

        private bool ModulExists(int id)
        {
            return _context.Moduls.Any(e => e.ModulID == id);
        }
    }
}
