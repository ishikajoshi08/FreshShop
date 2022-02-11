using FreshShop.Models;
using FreshShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository = null;
       
        public ProductController()
        {
            _productRepository = new ProductRepository();
        }
        
        public ViewResult GetAllProducts()
        {
            var data = _productRepository.GetAllProducts();
            return View(data);
        }

        public ViewResult GetProduct(int id)
        {
            var data = _productRepository.GetProductById(id);
            return View(data);
        }

        public List<ProductModel> SearchProduct(string productName , string desc, string price, string category)
        {
            return _productRepository.SearchProduct(productName, desc, price, category);
        }
    }
}
