using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
