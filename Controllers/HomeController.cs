using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notentool.Models;
using Notentool.Models.Entities;
using Notentool.Services;

namespace Notentool.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, Context context, IUserService userService)
        {
            _logger = logger;
            _context = context;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetOrCreateUser(User);
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

        [HttpGet]
        public ActionResult FriendDetail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModulErstellen(Modul modul)
        {
            _context.Moduls.Add(modul);
            _context.SaveChanges();
            return View();
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
