using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EL.Common;
using EL.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace EL.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IDistributedCache _cache;
        public LoginController(IAccountService accountService, IDistributedCache cache)
        {
            _accountService = accountService;
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAuthCode()
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return File(new VerifyCode().GetVerifyCode(ipAddress), @"image/Gif");
        }

        [HttpPost]
        public async Task<ActionResult> Login(string suId, string suPwd, string suCode)
        {
            var code = RedisHelper.Get(HttpContext.Connection.RemoteIpAddress.ToString());
            var a = Md5Helper.GetMD5_32(suCode.ToLower());
            if (string.IsNullOrWhiteSpace(suCode) || string.IsNullOrWhiteSpace(code) || Md5Helper.GetMD5_32(suCode.ToLower()) != code)
            {
                return Json(new { code = -10 });
            }
            var login = await _accountService.Login(suId, Md5Helper.GetMD5_32(suPwd));
            if (login == null)
            {
                return Json(new { code = -11 });
            }
            HttpContext.Session.SetInt32("uid", login.Id);
            return Json(new { code = 0 });
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login", null);
        }
    }
}