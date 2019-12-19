using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EL.Application;
using EL.Entity;

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
            //var model = new MenuEntity()
            //{
            //    Name = "A",
            //    CreateTime = DateTime.Now
            //};
            //_menuService.Add(model);
            //var model1 = new MenuEntity()
            //{
            //    Name = "A1",
            //    ParentMenu = _menuService.GetMenu(1),
            //    CreateTime = DateTime.Now
            //};
            //_menuService.Add(model1);
            //var model2 = new MenuEntity()
            //{
            //    Name = "A1-A2",
            //    ParentMenu = _menuService.GetMenu(2),
            //    CreateTime = DateTime.Now
            //};
            //_menuService.Add(model2);
            //var a = _menuService.GetMenu(1);
            //var b = _menuService.GetMenu(2);
            //var c = _menuService.GetMenu(3);
            return View();
        }
    }
}