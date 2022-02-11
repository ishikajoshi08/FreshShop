using FreshShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Repository
{
    public class ProductRepository
    {
        public List<ProductModel> GetAllProducts()
        {
            return DataSource();
        }

        public ProductModel GetProductById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<ProductModel> SearchProduct(string productname, string desc, string price, string category)
        {
            return DataSource().Where(x => x.ProductName.Contains(productname) || x.Description.Contains(desc) || x.Price.Contains(price) || x.Category.Contains(category)).ToList();
        }

        private List<ProductModel> DataSource()
        {
            return new List<ProductModel>
            {
                new ProductModel(){Id=1 , ProductName="Apple", Description="This is fruit", Price="Rs 100/kg" , Category="Fruit"},
                new ProductModel(){Id=2 , ProductName="Mango", Description="This is fruit", Price="Rs 150/kg" , Category="Fruit"},
                new ProductModel(){Id=3 , ProductName="Potato", Description="This is vegetable", Price="Rs 30/kg" , Category="Vegetable"},
                new ProductModel(){Id=4 , ProductName="Onion", Description="This is vegetable", Price="Rs 80/kg" , Category="Vegetable"},
                new ProductModel(){Id=5 , ProductName="Strawberry", Description="This is fruit", Price="Rs 60/kg" , Category="Fruit"}
            };
        }
    }
}
