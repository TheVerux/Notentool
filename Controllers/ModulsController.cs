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
    [Route("semesters/{semesterId}/[controller]")]
    public class ModulsController : Controller
    {
        private readonly IModulsService _modulsService;
        private readonly ISemestersService _semestersService;

        public ModulsController(IModulsService modulsService, ISemestersService semestersService)
        {
            _modulsService = modulsService;
            _semestersService = semestersService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int semesterId)
        {
            var semester = await _semestersService.GetSemesterByIdAsync(semesterId);
            ViewData["Semester"] = semester;

            var moduls = _modulsService.GetAllModuls(semesterId);
            return View(moduls);
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
                var semester = await _semestersService.GetSemesterByIdAsync(semesterId);
                await _modulsService.CreateModulAsync(modul, semester);
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

            var modul = await _modulsService.GetModulByIdAsync(id.Value);
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
                    var semester = await _semestersService.GetSemesterByIdAsync(semesterId);
                    await _modulsService.UpdateModulAsync(modul, semester);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_modulsService.ModulExists(modul.ModulID))
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

            var modul = await _modulsService.GetModulByIdAsync(id.Value);
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
            await _modulsService.DeleteModulAsync(id);
            return RedirectToAction(nameof(Index), new { semesterId });
        }
    }
}
