using FreshShop.Data;
using FreshShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshShop.Utility;

namespace FreshShop.Controllers
{
    public class OrderController : Controller
    {
        private FreshShopContext _db;
        public OrderController(FreshShopContext db)
        {
            _db = db;
        }

        //Get Checkout
        public IActionResult Checkout()
        {
            return View();
        }

        //Post Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Order anOrder)
        {
            List<Products> products = HttpContext.Session.GetObjectFromJson<List<Products>>("products");
            if(products! == null)
            {
                foreach(var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.Id = product.Id;
                    anOrder.OrderDetails.Add(orderDetails);
                }
            }
            _db.Orders.Add(anOrder);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("products",null);
            return View();
        }

        public string GetOrderNo()
        {
            int rowCount = _db.Orders.ToList().Count()+1;
            return rowCount.ToString("000");
        }
    }
}
