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
        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetVerifyCode()
        {
            var verifyCode = new VerifyCodeHelper().GetVerifyCode(out string code);
            HttpContext.Session.SetString("VerifyCode", DESEncrypt.Encrypt(code));
            return File(verifyCode, @"image/Gif");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="suId">登录账号</param>
        /// <param name="suPwd">登录密码</param>
        /// <param name="suCode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Login(string suId, string suPwd, string suCode)
        {
            var code = DESEncrypt.Decrypt(HttpContext.Session.GetString("VerifyCode"));
            if (string.IsNullOrWhiteSpace(suCode) || string.IsNullOrWhiteSpace(code) || suCode != code)
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

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login", null);
        }
    }
}