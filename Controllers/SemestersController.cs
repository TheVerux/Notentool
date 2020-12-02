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
    /// <summary>
    /// Controller Klasse für Semester. Handhabt die Logik für die Views der Semester.
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    public class SemestersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISemestersService _semestersService;

        public SemestersController(IUserService userService, ISemestersService semestersService)
        {
            _userService = userService;
            _semestersService = semestersService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetOrCreateUser(User);
            var semesters =  _semestersService.GetAllSemesters(user);
            return View(semesters);
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
                await _semestersService.CreateSemesterAsync(semester, user);
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

            var semester = await _semestersService.GetSemesterByIdAsync(id.Value);
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
                    var user = await _userService.GetOrCreateUser(User);
                    await _semestersService.UpdateSemesterAsync(semester, user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_semestersService.SemesterExists(semester.SemesterID))
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

            var semester = await _semestersService.GetSemesterByIdAsync(id.Value);
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
            await _semestersService.DeleteSemesterAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
