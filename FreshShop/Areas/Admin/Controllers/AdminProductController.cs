using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminProductController : Controller
    {
        [Route("AddNewProduct")]
        public IActionResult AddNewProduct()
        {
            return View();
        }

        [Route("ViewProduct")]
        public IActionResult ViewProduct()
        {
            return View();
        }
    }
}
