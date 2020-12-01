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
using Notentool.Services;

namespace Notentool.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class SemestersController : Controller
    {
        private readonly Context _context;
        private readonly IUserService _userService;

        public SemestersController(Context context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetOrCreateUser(User);
            var semesters = await _context.Semesters.Where(s => s.Benutzeraccount.Id == user.Id)
                .Include(s => s.Moduls)
                .ThenInclude(m => m.Grades)
                .ToListAsync();
            return View(semesters);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters
                .FirstOrDefaultAsync(m => m.SemesterID == id);
            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public async Task<IActionResult> Create([Bind("SemesterID,Name")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetOrCreateUser(User);
                semester.Benutzeraccount = user;
                _context.Add(semester);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(semester);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters.FindAsync(id);
            if (semester == null)
            {
                return NotFound();
            }
            return View(semester);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("SemesterID,Name")] Semester semester)
        {
            if (id != semester.SemesterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (semester.Benutzeraccount == null)
                    {
                        var user = await _userService.GetOrCreateUser(User);
                        semester.Benutzeraccount = user;
                    }
                    _context.Update(semester);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SemesterExists(semester.SemesterID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(semester);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters
                .FirstOrDefaultAsync(m => m.SemesterID == id);
            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var semester = await _context.Semesters.FindAsync(id);
            _context.Semesters.Remove(semester);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SemesterExists(int id)
        {
            return _context.Semesters.Any(e => e.SemesterID == id);
        }
    }
}
