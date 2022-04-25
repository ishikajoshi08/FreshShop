using FreshShop.Data;
using FreshShop.Models;
using FreshShop.Repository;
using FreshShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace FreshShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository = null;
        private readonly ICategoryRepository _categoryRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private FreshShopContext _db;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment, FreshShopContext db)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        public async Task<ViewResult> GetAllProducts()
        {
            var data = await _productRepository.GetAllProducts();
            return View(data);
        }

        [Route("product-details/{id}", Name = "productDetailsRoute")]
        public async Task<ViewResult> GetProduct(int id)
        {
            var data = await _productRepository.GetProductById(id);
            return View(data);
        }

        public List<ProductModel> SearchProduct(string productName, string desc, string price, string category)
        {
            return _productRepository.SearchProduct(productName, desc, price, category);
        }

        //[Authorize]
        public ViewResult AddNewProduct(bool isSuccess = false, int productId = 0)
        {
            var model = new ProductModel();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = productId;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewProduct(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var searchProduct = _db.Products.FirstOrDefault(c => c.ProductName == productModel.ProductName);
                if(searchProduct!=null)
                {
                    ViewBag.message = "This product already exists";
                    return View(productModel);
                }
                if (productModel.CoverPhoto != null)
                {
                    string folder = "Products/Cover/";
                    productModel.CoverImageUrl = await UploadImage(folder, productModel.CoverPhoto);
                }

                if (productModel.GalleryFiles != null)
                {
                    string folder = "Products/Gallery/";
                    productModel.Gallery = new List<GalleryModel>();

                    foreach (var file in productModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        productModel.Gallery.Add(gallery);
                    }
                }
                int id = await _productRepository.AddNewProduct(productModel);
                TempData["save"] = "Product has been saved sucessfully";
                if (id > 0)
                {
                    return RedirectToAction("Index","ViewProduct", new { isSuccess = true, productId = id });
                }
            }
            //ViewBag.Category = new SelectList(await _categoryRepository.GetCategories(), "Id", "Name");

            return View();

        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
            return "/" + folderPath;
        }

        //GET Edit Action Method
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var products = _db.Products.FirstOrDefault(c=>c.Id==id);
            if(products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        //POST Edit Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Products products, IFormFile image)
        {
            if(ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_webHostEnvironment.WebRootPath + "/Products/Cover", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.CoverPhoto = "Products/Cover/" + image.FileName;
                }
                //if (image == null)
                //{
                //    return NotFound();
                //}
                _db.Products.Update(products);
                await _db.SaveChangesAsync();
                TempData["update"] = "Product has been saved sucessfully";
                return RedirectToAction("Index", "ViewProduct");
            }
            
            
            return View(products);
        }


        //GET Details Action Method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        //POST Details Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Products products)
        {
            return RedirectToAction("Index", "ViewProduct");
        }

        //GET Delete Action Method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        //POST Delete Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Products products)
        {
            if (id==null)
            {
                return NotFound();
            }
            if (id != products.Id)
            {
                return NotFound();
            }
            var product = _db.Products.Find(id);
            if (product==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "ViewProduct");
            }
            return View(products);

        }
    }
}