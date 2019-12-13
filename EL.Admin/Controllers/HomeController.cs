using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EL.Common;
using EL.Admin.Models;
using EL.Application.Log;

namespace EL.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly ILogService _logService;
        public HomeController(ILogger<HomeController> logger, ILogService logService)
        {
            _logger = logger;
            _logService = logService;
        }

        public IActionResult Index()
        {
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
