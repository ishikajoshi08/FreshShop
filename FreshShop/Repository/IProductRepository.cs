using FreshShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreshShop.Repository
{
    public interface IProductRepository
    {
        Task<int> AddNewProduct(ProductModel model);
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int id);
        List<ProductModel> SearchProduct(string productname, string desc, string price, string category);
    }
}