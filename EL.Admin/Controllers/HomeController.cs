using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EL.Common;
using EL.Admin.Models;
using EL.Application.Log;

namespace EL.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogService _logService;
        public HomeController(ILogService logService)
        {
            _logService = logService;
        }

        public IActionResult Index()
        {
            Logger.Write("123456789");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
