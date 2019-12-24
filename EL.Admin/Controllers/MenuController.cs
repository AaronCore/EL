using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EL.Application;
using EL.Entity;
using EL.Common;

namespace EL.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTreeList()
        {
            var list = _menuService.GetMenuTreeList();
            return Json(list);
        }

        [HttpGet]
        public IActionResult GetMenuList()
        {
            var list = _menuService.GetMenuList();
            return Json(list);
        }

        [HttpGet]
        public IActionResult GetMenu(int id)
        {
            var model = _menuService.GetMenu(id);
            var obj = new
            {
                parentId = model.ParentMenu != null ? model.ParentMenu.Id : 0,
                model.Id,
                model.Name,
                model.Path,
                model.Code,
                model.Icon,
                model.Enabled,
                model.Sort
            };
            return Json(obj);
        }

        [HttpPost]
        public IActionResult Submit(Menu_DTO entity)
        {
            _menuService.Submit(entity);
            return Json(new { code = 0 });
        }

        [HttpPost]
        public IActionResult Deletes(int[] ids)
        {
            var status = _menuService.Deletes(ids);
            return Json(new { code = status ? 0 : -2 });
        }

        [HttpPost]
        public IActionResult Enableds(int[] ids)
        {
            _menuService.Enableds(ids);
            return Json(new { code = 0 });
        }
    }
}