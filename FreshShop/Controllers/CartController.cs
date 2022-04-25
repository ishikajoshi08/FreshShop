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
        [Authorize]
        [Route("index")]
        public IActionResult Index()
        {
            try
            {
                var cart = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(i => i.Products.Price * i.Quantity);
            }
            catch (Exception)
            {
                ViewBag.total = 0;
                return View();
            }
            return View();
        }
        [Authorize]
        [Route("wishlist")]
        public IActionResult Wishlist()
        {
            var wishlist = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "wishlist");
            ViewBag.wishlist = wishlist;
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
                TempData["TotalCount"] = cart.Count();
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
                TempData["TotalCount"] = cart.Count();
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
                TempData["TotalCount"] = cart.Count();
                return RedirectToAction("Index");
        }

        public IActionResult Decrease(int id)
        {
            return View();
        }

        [Authorize]
        [Route("AddWishlist/{id}")]
        public IActionResult AddWishlist(int id)
        {
            if (SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "wishlist") == null)
            {
                var wishlist = new List<Item>();
                wishlist.Add(new Item() { Products = _db.Products.Find(id), Quantity = 1 });
                SessionExtensions.SetObjectAsJson(HttpContext.Session, "wishlist", wishlist);
                TempData["TotalCountW"] = wishlist.Count();
            }
            else
            {
                var wishlist = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "wishlist");
                int index = ExistsW(wishlist, id);
                if (index == -1)
                {
                    wishlist.Add(new Item() { Products = _db.Products.Find(id), Quantity = 1 });

                }
                else
                {
                    wishlist[index].Quantity++;
                }
                SessionExtensions.SetObjectAsJson(HttpContext.Session, "wishlist", wishlist);
                TempData["TotalCountW"] = wishlist.Count();
            }
            return RedirectToAction("Wishlist");
        }

        [Route("RemoveWishlist/{id}")]
        public IActionResult RemoveWishlist(int id)
        {
            var wishlist = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "wishlist");
            int index = ExistsW(wishlist, id);
            wishlist.RemoveAt(index);
            SessionExtensions.SetObjectAsJson(HttpContext.Session, "wishlist", wishlist);
            TempData["TotalCountW"] = wishlist.Count();
            return RedirectToAction("Wishlist");
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

        private int ExistsW(List<Item> wishlist, int id)
        {
            for (int i = 0; i < wishlist.Count; i++)
            {
                if (wishlist[i].Products.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
