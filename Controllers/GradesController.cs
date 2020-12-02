using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notentool.Models.Entities;
using Notentool.Services;

namespace Notentool.Controllers
{
    /// <summary>
    /// Controller Klasse für Noten. Handhabt die Logik für die Views der Noten.
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
    [Authorize]
    [Route("moduls/{modulId}/[controller]")]
    public class GradesController : Controller
    {
        private readonly IGradesService _gradesService;
        private readonly IModulsService _modulsService;

        public GradesController(IGradesService gradesService, IModulsService modulsService)
        {
            _gradesService = gradesService;
            _modulsService = modulsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int modulId)
        {
            var modul = await _modulsService.GetModulByIdAsync(modulId);
            ViewData["Modul"] = modul;

            var grades = _gradesService.GetAllGrades(modulId);
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

            var grade = await _gradesService.GetGradeByIdAsync(id.Value);
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
                var modul = await _modulsService.GetModulByIdAsync(modulId);
                await _gradesService.CreateGradeAsync(grade, modul);
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

            var grade = await _gradesService.GetGradeByIdAsync(id.Value);
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
                    var modul = await _modulsService.GetModulByIdAsync(modulId);
                    await _gradesService.UpdateGradeAsync(grade, modul);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_gradesService.GradeExists(grade.GradeID))
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

            var grade = await _gradesService.GetGradeByIdAsync(id.Value);
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
            await _gradesService.DeleteGradeAsync(id);
            return RedirectToAction(nameof(Index), new { modulId });
        }
    }
}
