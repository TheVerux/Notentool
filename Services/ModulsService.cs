using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notentool.Models.Entities;

namespace Notentool.Services
{
    /// <summary>
    /// Implementierung des <c>IModulsService</c>
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
    public class ModulsService : IModulsService
    {
        private readonly Context _context;

        public ModulsService(Context context)
        {
            _context = context;
        }

        public IEnumerable<Modul> GetAllModuls(int semesterId)
        {
            return _context.Moduls.Where(m => m.SemesterID == semesterId)
                .Include(m => m.Grades);
        }

        public async Task<Modul> GetModulByIdAsync(int id)
        {
            return await _context.Moduls
                .Include(m => m.Grades)
                .FirstOrDefaultAsync(m => m.ModulID == id);
        }

        public async Task CreateModulAsync(Modul modul, Semester semester)
        {
            modul.Semester = semester;
            _context.Add(modul);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateModulAsync(Modul modul, Semester semester)
        {
            modul.Semester ??= semester;
            _context.Update(modul);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteModulAsync(int id)
        {
            var modul = await _context.Moduls
                .Include(m => m.Grades)
                .FirstOrDefaultAsync(m => m.ModulID == id);
            _context.Moduls.Remove(modul);
            await _context.SaveChangesAsync();
        }

        public bool ModulExists(int id)
        {
            return _context.Moduls.Any(m => m.ModulID == id);
        }
    }
}
