using FreshShop.Data;
using FreshShop.Models;
using FreshShop.Repository;
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


        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
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

        public List<ProductModel> SearchProduct(string productName , string desc, string price, string category)
        {
            return _productRepository.SearchProduct(productName, desc, price, category);
        }

        [Authorize]
        public async Task<ViewResult> AddNewProduct(bool isSuccess = false, int productId = 0)
        {
            var model = new ProductModel();
            //ViewBag.Category = new List<string>() { "Fruit", "Vegetable" };
            //ViewBag.Category = new SelectList(GetCategory(), "Id", "Text");

            //var group1 = new SelectListGroup() { Name = "Fruit" };
            //var group2 = new SelectListGroup() { Name = "Vegetable" };
            //ViewBag.Category = new SelectList( await _categoryRepository.GetCategories(), "Id","Name");

            //ViewBag.Category = new List<SelectListItem>()
            //{
            //     new SelectListItem(){Text = "Summer Fruit", Value = "1",Group = group1 },
            //     new SelectListItem(){Text = "Winter Fruit", Value = "2",Group = group1},
            //     new SelectListItem(){Text = "Monsoon Fruit", Value = "3",Group = group1},
            //     new SelectListItem(){Text = "Summer Veggie", Value = "4",Group = group2},
            //     new SelectListItem(){Text = "Winter Veggie", Value = "5",Group = group2},
            //     new SelectListItem(){Text = "Monsoon Veggie", Value = "6",Group = group2},
            //};
        

            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = productId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModel productModel)
        {
            if(ModelState.IsValid)
            {
                if(productModel.CoverPhoto != null)
                {
                    string folder = "Products/Cover/";
                    productModel.CoverImageUrl = await UploadImage(folder, productModel.CoverPhoto);
                }

                if (productModel.GalleryFiles != null)
                {
                    string folder = "Products/Gallery/";
                    productModel.Gallery = new List<GalleryModel>();

                    foreach(var file in productModel.GalleryFiles)
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
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewProduct), new { isSuccess = true, productId = id });
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
    }
}
