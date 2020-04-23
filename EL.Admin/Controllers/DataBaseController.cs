using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EL.Admin.Controllers
{
    public class DataBaseController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}