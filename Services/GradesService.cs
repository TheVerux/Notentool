using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notentool.Models.Entities;

namespace Notentool.Services
{
    /// <summary>
    /// Implementierung des <c>IGradesService</c>
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
    public class GradesService : IGradesService
    {
        private readonly Context _context;

        public GradesService(Context context)
        {
            _context = context;
        }

        public IEnumerable<Grade> GetAllGrades(int modulId)
        { 
            return _context.Grades.Where(g => g.ModulID == modulId);
        }

        public async Task<Grade> GetGradeByIdAsync(int id)
        {
            return await _context.Grades.FindAsync(id);
        }

        public async Task CreateGradeAsync(Grade grade, Modul modul)
        {
            grade.Modul = modul;
            _context.Add(grade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGradeAsync(Grade grade, Modul modul)
        {
            grade.Modul ??= modul;
            _context.Update(grade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGradeAsync(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }

        public bool GradeExists(int id)
        {
            return _context.Grades.Any(g => g.GradeID == id);
        }
    }
}
