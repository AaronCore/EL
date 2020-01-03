using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using EL.Common;
using EL.Application;

namespace EL.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string password, string newPassword)
        {
            int uid = HttpContext.Session.GetInt32("uid") ?? 0;
            int r = await _accountService.ResetPassword(uid, password, newPassword);
            if (r == 0)
            {
                HttpContext.Session.Clear();
            }
            return Json(new { code = r });
        }
    }
}
