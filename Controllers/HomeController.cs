using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Notentool.Models;
using Notentool.Models.Entities;
using Notentool.Services;

namespace Notentool.Controllers
{
    /// <summary>
    /// Default Controller. Steuert die Logik für die Startseiten und default Views.
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
    [Authorize]
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISemestersService _semestersService;

        public HomeController(IUserService userService, ISemestersService semestersService)
        {
            _userService = userService;
            _semestersService = semestersService;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetOrCreateUser(User);
            var semesters = _semestersService.GetAllSemesters(user).ToList();
            var currentSemester = semesters.FirstOrDefault(s => s.SemesterID == semesters.Max(s => s.SemesterID));
            ViewData["Semester"] = currentSemester;
            return View(currentSemester != null ? currentSemester.Moduls : new List<Modul>());
        }

        [Route("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/error")]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
