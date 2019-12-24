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
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetLogPageList(int pageIndex, int pageSize, string searchKey = null)
        {
            int total = 0;
            var list = _logService.GetLogPageList(pageIndex, pageSize, out total, searchKey);
            var obj = new
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
            };
            return Json(obj);
        }

        [HttpPost]
        public IActionResult Deletes(int[] ids)
        {
            var status = _logService.Deletes(ids);
            return Json(new { code = status ? 0 : -2 });
        }

        [HttpGet]
        public IActionResult GetLog(int id)
        {
            var entity = _logService.GetLog(id);
            var obj = new
            {
                entity.Id,
                entity.Message,
                entity.Exception,
                entity.StackTrace,
                CreateTime = entity.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
            };
            return Json(obj);
        }
    }
}