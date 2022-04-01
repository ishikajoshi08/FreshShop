using FreshShop.Models;
using FreshShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        
        public ViewResult Index()
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

        [Route("contact")]
        public ViewResult ContactUs()
        {
            return View();
        }

        [Route("contact")]
        [HttpPost]
        public IActionResult ContactUs(ContactFormModel model)
        {
            //Read SMTP settings from AppSettings.json.
            string host = this.configuration.GetValue<string>("Smtp:Server");
            int port = this.configuration.GetValue<int>("Smtp:Port");
            string fromAddress = this.configuration.GetValue<string>("Smtp:FromAddress");
            string userName = this.configuration.GetValue<string>("Smtp:UserName");
            string password = this.configuration.GetValue<string>("Smtp:Password");

            using (MailMessage mm = new MailMessage(fromAddress, "ishika08joshi@gmail.com"))
            {
                mm.Subject = "Testing";
                mm.Body = "Name: " + model.Name + "<br /><br />Email: " + model.Email + "<br />" + model.Message;
                mm.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential NetworkCred = new NetworkCredential(userName, password);
                    smtp.Credentials = NetworkCred;
                    smtp.EnableSsl = true;
                    smtp.Send(mm);
                    ViewBag.Message = "Email sent sucessfully.";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
