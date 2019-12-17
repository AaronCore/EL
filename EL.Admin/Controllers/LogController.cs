using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EL.Application;

namespace EL.Admin.Controllers
{
    public class LogController : BaseController
    {
        private readonly ILogService _logService;
        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetLogListJson(int pageIndex, int pageSize, string searchKey = null)
        {
            int total = 0;
            var list = _logService.GetLogList(pageIndex, pageSize, out total, searchKey);
            var obj = new
            {
                code = 0,
                message = "OK",
                result = new
                {
                    pageIndex,
                    pageSize,
                    total,
                    data = list.Select(p => new
                    {
                        p.Id,
                        p.Message,
                        CreateTime = p.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                    })
                }
            };
            return Json(obj);
        }
    }
}