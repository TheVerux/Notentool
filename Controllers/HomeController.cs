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
    [Authorize]
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        private readonly IUserService _userService;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly UserManager<Benutzeraccount> _userManager;

        public HomeController(ILogger<HomeController> logger, Context context, IUserService userService, RoleManager<UserRole> roleManager, UserManager<Benutzeraccount> userManager)
        {
            _logger = logger;
            _context = context;
            _userService = userService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetOrCreateUser(User);
            var semesters = await _context.Semesters.Where(s => s.Benutzeraccount.Id == user.Id)
                .Include(s => s.Moduls)
                .ThenInclude(m => m.Grades)
                .ToListAsync();
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
