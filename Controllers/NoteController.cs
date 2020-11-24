using Microsoft.AspNetCore.Mvc;
using Notentool.Models.Entities;

namespace Notentool.Controllers
{
    public class NoteController : Controller
    {
        private readonly Context _context;

        public NoteController(Context context)
        {
            _context = context;
        }

        public IActionResult Note()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult NoteErstellen(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
            return Ok();
        }
    }
}