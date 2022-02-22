using FreshShop.Data;
using FreshShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly FreshShopContext _context = null;

        public ProductRepository(FreshShopContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewProduct(ProductModel model)
        {
            var newProduct = new Products()
            {
                ProductName = model.ProductName,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl
            };

            newProduct.productGallery = new List<ProductGallery>();
            foreach (var file in model.Gallery)
            {
                newProduct.productGallery.Add(new ProductGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return newProduct.Id;
        }
        public async Task<List<ProductModel>> GetAllProducts()
        {
            var products = new List<ProductModel>();
            var allproducts = await _context.Products.ToListAsync();
            if (allproducts?.Any() == true)
            {
                foreach (var product in allproducts)
                {
                    products.Add(new ProductModel()
                    {
                        ProductName = product.ProductName,
                        Description = product.Description,
                        Price = product.Price,
                        Id = product.Id,
                        CategoryId = product.CategoryId,
                        CoverImageUrl = product.CoverImageUrl
                        //Category = product.Category.Name                       
                    });
                }
            }
            return products;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _context.Products.Where(x => x.Id == id)
                .Select(product => new ProductModel()
                {
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    Category = product.Category.Name,
                    CoverImageUrl = product.CoverImageUrl,
                    Gallery = product.productGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL

                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public List<ProductModel> SearchProduct(string productname, string desc, string price, string category)
        {
            return null;
        }


    }
}
