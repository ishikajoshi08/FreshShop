using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshShop.Utility;
using FreshShop.Models;
using FreshShop.Data;
using Microsoft.AspNetCore.Authorization;

namespace FreshShop.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private FreshShopContext _db;
        public CartController(FreshShopContext db)
        {
                 _db = db;
        }
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(i => i.Products.Price * i.Quantity);
            return View();
        }

        [Authorize]
        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if(SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<Item>();
                cart.Add(new Item() { Products = _db.Products.Find(id), Quantity = 1 });
                SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, id);
                if(index == -1)
                {
                    cart.Add(new Item() { Products = _db.Products.Find(id), Quantity = 1 });

                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }


        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            
                var cart = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, id);
                cart.RemoveAt(index);
                SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToAction("Index");
        }



        private int Exists(List<Item> cart, int id)
        {
            for(int i=0;i<cart.Count; i++)
            {
                if(cart[i].Products.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
