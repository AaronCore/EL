using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EL.Admin.Controllers
{
    public class BasisController : Controller
    {
        public IActionResult Icon()
        {
            return View();
        }
    }
}