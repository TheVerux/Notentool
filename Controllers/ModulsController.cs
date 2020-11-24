using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notentool;
using Notentool.Models.Entities;

namespace Notentool.Controllers
{
    public class ModulsController : Controller
    {
        private readonly Context _context;

        public ModulsController(Context context)
        {
            _context = context;
        }

        // GET: Moduls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moduls.ToListAsync());
        }

        // GET: Moduls/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Moduls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moduls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModulID,Name")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modul);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modul);
        }

        // GET: Moduls/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Moduls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModulID,Name")] Modul modul)
        {
            if (id != modul.ModulID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction(nameof(Index));
            }
            return View(modul);
        }

        // GET: Moduls/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Moduls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modul = await _context.Moduls.FindAsync(id);
            _context.Moduls.Remove(modul);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModulExists(int id)
        {
            return _context.Moduls.Any(e => e.ModulID == id);
        }
    }
}
