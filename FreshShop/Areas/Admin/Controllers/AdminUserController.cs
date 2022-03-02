using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminUserController : Controller
    {
        [Route("AddNewUser")]
        public IActionResult AddNewUser()
        {
            return View();
        }

        [Route("ViewUser")]
        public IActionResult ViewUser()
        {
            return View();
        }
    }
}
