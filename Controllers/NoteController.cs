using Microsoft.AspNetCore.Mvc;
using Notentool.Models.Entities;
using System.Threading.Tasks;

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
        public async Task<ActionResult> NoteErstellen(Modul modul, Grade grade)
        {
            //Fetching Grade Records in LIST Collection format.
            var a = _context.Grades.AddAsync(grade);
            modul.Grades.Add(grade);
            _context.Moduls.Update(modul);

            //Creating ViewBag named ModulListItem to used in VIEW.  
            ViewBag.ModulListItem = ModulController.ToSelectListModul(grades);
            _context.Moduls.Add(grades);
            _context.SaveChanges();
            return View();
        }
    }
}