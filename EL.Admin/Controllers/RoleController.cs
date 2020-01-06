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
    public class RoleController : BaseController
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
        public async Task<IActionResult> GetRoleMenu(int id)
        {
            var list = await _roleService.GetRoleMenuList(id);
            ArrayList array = new ArrayList();
            foreach (var item in list)
            {
                array.Add(item.MenuId);
            }
            return Json(new { code = 0, menuIds = array });
        }

        [HttpPost]
        public async Task<IActionResult> RoleMenuSubmit(int roleId, int[] menuIds)
        {
            await _roleService.RoleMenuSubmit(roleId, menuIds);
            return Json(new { code = 0 });
        }

        [HttpGet]
        public async Task<IActionResult> GetRole(int id)
        {
            var model = await _roleService.GetRole(id);
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
        public async Task<IActionResult> Submit(RoleEntity entity)
        {
            var result = await _roleService.Submit(entity);
            return Json(new { code = result });
        }

        [HttpPost]
        public IActionResult GetRolePageList(int pageIndex, int pageSize, string searchKey = null)
        {
            int total = 0;
            var list = _roleService.GetRolePageList(pageIndex, pageSize, out total, searchKey);
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
        public async Task<IActionResult> Deletes(int[] ids)
        {
            var status = await _roleService.Deletes(ids);
            return Json(new { code = status ? 0 : -2 });
        }

        [HttpPost]
        public async Task<IActionResult> Enableds(int[] ids)
        {
            await _roleService.Enableds(ids);
            return Json(new { code = 0 });
        }
    }
}