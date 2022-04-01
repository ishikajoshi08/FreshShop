using FreshShop.Data;
using FreshShop.Models;
using FreshShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class AdminProductController : Controller
    {
        private FreshShopContext _db;

        public AdminProductController(FreshShopContext db)
        {
            _db = db;
        }

        [Route("ViewProduct")]
        public IActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        [Route("ViewProduct")]
        [HttpPost]
        public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        {
            var products = _db.Products.Where(c => c.Price >= lowAmount && c.Price <= largeAmount).ToList();
            if(lowAmount==null || largeAmount==null)
            {
                products = _db.Products.ToList();
            }
            return View(products);
        }
    }
}
