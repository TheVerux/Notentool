using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notentool.Models.Entities;
using System;
using System.Collections.Generic;

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
            //Fetching semesters Records in LIST Collection format.  
            var semesters = (_context.Semesters);

            //Creating ViewBag named SemesterListItem to used in VIEW.  
            ViewBag.SemesterListItem = SemesterController.ToSelectListSemester();
            _context.Moduls.Add(modul);
            _context.SaveChanges();
            return View();
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
    }
}