using Microsoft.AspNetCore.Mvc;
using Notentool.Models.Entities;

namespace Notentool.Controllers
{
    public class ModulController : Controller
    {
        private readonly Context _context;

        public ModulController(Context context)
        {
            _context = context;
        }

        public IActionResult Modul()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult ModulErstellen(Modul modul)
        {
            _context.Moduls.Add(modul);
            _context.SaveChanges();
            return Ok();
        }
    }
}