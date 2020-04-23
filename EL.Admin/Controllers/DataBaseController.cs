using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EL.Application;
using Microsoft.AspNetCore.Mvc;

namespace EL.Admin.Controllers
{
    public class DataBaseController : BaseController
    {
        private readonly IDataBaseService _dataBaseService;

        public DataBaseController(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDataBases()
        {
            var result = await _dataBaseService.GetDataBases();
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTables(string dataBase)
        {
            var result = await _dataBaseService.GetDataBaseTables(dataBase);
            var obj = result.Select(p => new
            {
                name = p
            });
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> TableSearch(string dataBase, string search)
        {
            var list = await _dataBaseService.GetDataBaseTables(dataBase);
            var result = list.Where(p => p.Contains(search));
            var obj = result.Select(p => new
            {
                name = p
            });
            return Json(obj);
        }
    }
}