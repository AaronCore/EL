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
        public async Task<IActionResult> GetTreeList()
        {
            var list = await _menuService.GetMenuTreeList();
            return Json(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuList()
        {
            var list = await _menuService.GetMenuList();
            return Json(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetSelectMenuList()
        {
            var list = await _menuService.GetSelectMenuList();
            return Json(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetMenu(int id)
        {
            var model = await _menuService.GetMenu(id);
            var obj = new
            {
                model.ParentId,
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
        public async Task<IActionResult> Submit(MenuEntity entity)
        {
            var result = await _menuService.Submit(entity);
            return Json(new { code = result });
        }

        [HttpPost]
        public async Task<IActionResult> Deletes(int[] ids)
        {
            var status = await _menuService.Deletes(ids);
            return Json(new { code = status ? 0 : -2 });
        }

        [HttpPost]
        public async Task<IActionResult> Enableds(int[] ids)
        {
            await _menuService.Enableds(ids);
            return Json(new { code = 0 });
        }
    }
}