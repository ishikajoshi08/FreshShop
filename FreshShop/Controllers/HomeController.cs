using FreshShop.Models;
using FreshShop.Services;
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
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(IConfiguration _configuration,IUserService userService,IEmailService emailService)
        {
            configuration = _configuration;
            _userService = userService;
            _emailService = emailService;
        }
        
        public async Task<ViewResult> Index()
        {
            //UserEmailOptions options = new UserEmailOptions
            //{
            //    ToEmails = new List<string>() { "test@gmail.com" },
            //    PlaceHolders = new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{UserName}}","Litchi")
            //    }

            //};

            //await _emailService.SendTestEmail(options);


            //var userId = _userService.GetUserId();
            //var isLoggedIn = _userService.IsAuthenticated();

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
