using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Notentool.Models;

namespace Notentool.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Modul()
        {
            return View();
        }

        public IActionResult Note()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModulErstellen(Modul modul)
        {
            //Fetching Skills Records in LIST Collection format.  
            var semesters = (from a in _context.Semester orderby a.Title select a).ToList();

            //Creating ViewBag named SkillListItem to used in VIEW.  
            ViewBag.SemesterListItem = ToSelectListSemester(semesters);
            _context.Moduls.Add(modul);
            _context.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult NoteErstellen(Grade grade)
        {
            //Fetching Skills Records in LIST Collection format.  
            var grades = (from a in _context.Grade orderby a.Title select a).ToList();

            //Creating ViewBag named SkillListItem to used in VIEW.  
            ViewBag.ModulListItem= ToSelectListModul(semesters);
            _context.Moduls.Add(modul);
            _context.SaveChanges();
            return View();
        }

        [NonAction]
        public SelectList ToSelectListSemester(List<_context.Semester> semesters)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (_context.Semester item in semesters)
            {
                list.Add(new SelectListItem()
                { 
                    Text = item.Title
                });
            }

            return new SelectList(list, "Text");
        }

        [NonAction]
        public SelectList ToSelectListModul(List<_context.Modul> moduls)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (_context.Modul item in moduls)
            {
                list.Add(new SelectListItem()
                { 
                    Text = item.Title
                });
            }

            return new SelectList(list, "Text");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
