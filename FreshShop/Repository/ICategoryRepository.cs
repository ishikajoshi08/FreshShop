using FreshShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreshShop.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetCategories();
    }
}