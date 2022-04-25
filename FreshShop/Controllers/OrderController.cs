using FreshShop.Data;
using FreshShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshShop.Utility;
using FreshShop.Repository;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace FreshShop.Controllers
{
    public class OrderController : Controller
    {
        private FreshShopContext _db;
        private IConfiguration Configuration;

        public OrderController(FreshShopContext db, IConfiguration _configuration)
        {
            _db = db;
            Configuration = _configuration;
        }

        //Get Checkout
        public IActionResult Checkout()
        {
            return View();
        }

        //Post Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(Order order)
        {
            return View();
        }

        public IActionResult CheckoutComplete(Order model)
        {
            //Read SMTP settings from AppSettings.json.
            string host = this.Configuration.GetValue<string>("Smtp:Server");
            int port = this.Configuration.GetValue<int>("Smtp:Port");
            string fromAddress = this.Configuration.GetValue<string>("Smtp:FromAddress");
            string userName = this.Configuration.GetValue<string>("Smtp:UserName");
            string password = this.Configuration.GetValue<string>("Smtp:Password");

            using (MailMessage mm = new MailMessage(fromAddress, "18ishikajoshi@gmail.com"))
            {
                mm.Subject = "Order Placed";
                mm.Body = "Name: " + model.Name + "<br /><br />Email: " + model.Email + "<br />" + model.Address + "<br />" + "Order Number: ADE23456GHHJTB" + "<br />" + "Thank you for placing the order :)";
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
            return RedirectToAction("GetAllProducts","Product");
        }
    }
}
