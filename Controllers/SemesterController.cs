using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notentool.Models.Entities;

namespace Notentool.Controllers
{
    public class SemesterController : Controller
    {

        private readonly Context _context;

        public IActionResult Semester()
        {
            return View();
        }

        [NonAction]
        public static SelectList ToSelectListSemester(List<_context.Semester> semesters)
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
    }
}
