using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EL.Application;
using EL.Entity;
using EL.Common;
using System.Collections;

namespace EL.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetRoleMenuJson(int id)
        {
            var model = _roleService.GetRole(id);
            ArrayList array = new ArrayList();
            foreach (var item in model.RoleMenus)
            {
                array.Add(item.MenuId);
            }
            return Json(new { code = 0, menuIds = array });
        }

        [HttpPost]
        public IActionResult RoleMenuSubmit(int roleId, int[] menuIds)
        {
            _roleService.RoleMenuSubmit(roleId, menuIds);
            return Json(new { code = 0 });
        }

        [HttpGet]
        public IActionResult GetRoleJson(int id)
        {
            var model = _roleService.GetRole(id);
            var obj = new
            {
                model.Id,
                model.Name,
                model.Enabled,
                model.Sort
            };
            return Json(obj);
        }

        [HttpPost]
        public IActionResult Submit(RoleEntity entity)
        {
            _roleService.Submit(entity);
            return Json(new { code = 0 });
        }

        [HttpPost]
        public IActionResult GetRoleListJson(int pageIndex, int pageSize, string searchKey = null)
        {
            int total = 0;
            var list = _roleService.GetRoleList(pageIndex, pageSize, out total, searchKey);
            var obj = new
            {
                pageIndex,
                pageSize,
                total,
                data = list.Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Enabled,
                    p.Sort,
                    CreateTime = p.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                })
            };
            return Json(obj);
        }

        [HttpPost]
        public IActionResult Deletes(int[] ids)
        {
            var status = _roleService.Deletes(ids);
            return Json(new { code = status ? 0 : -2 });
        }

        [HttpPost]
        public IActionResult Enableds(int[] ids)
        {
            _roleService.Enableds(ids);
            return Json(new { code = 0 });
        }
    }
}