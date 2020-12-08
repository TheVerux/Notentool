using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notentool.Models.Entities;

namespace Notentool.Services
{
    /// <summary>
    /// Implementierung des <c>ISemestersService</c>
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
    public class SemestersService : ISemestersService
    {
        private readonly Context _context;

        public SemestersService(Context context)
        {
            _context = context;
        }

        public IEnumerable<Semester> GetAllSemesters(Benutzeraccount user)
        {
            return _context.Semesters.Where(s => s.BenutzeraccountId == user.Id)
                .Include(s => s.Moduls)
                .ThenInclude(m => m.Grades);
        }

        public async Task<Semester> GetSemesterByIdAsync(int id)
        {
            return await _context.Semesters
                .Include(s => s.Moduls)
                .ThenInclude(m => m.Grades)
                .FirstOrDefaultAsync(s => s.SemesterID == id);
        }

        public async Task CreateSemesterAsync(Semester semester, Benutzeraccount user)
        {
            semester.Benutzeraccount = user;
            _context.Add(semester);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSemesterAsync(Semester semester, Benutzeraccount user)
        {
            semester.Benutzeraccount ??= user;
            _context.Update(semester);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSemesterAsync(int id)
        {
            var semester = await _context.Semesters
                .Include(s => s.Moduls) // Die Includes müssen vorhanden sein, ansonsten können die Objekte wegen den Relationen nicht gelöscht werden
                .ThenInclude(m => m.Grades)
                .FirstOrDefaultAsync(s => s.SemesterID == id);
            _context.Semesters.Remove(semester);
            await _context.SaveChangesAsync();
        }

        public bool SemesterExists(int id)
        {
            return _context.Semesters.Any(e => e.SemesterID == id);
        }
    }
}
