using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DashboardController : Controller
    {
        //[Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
