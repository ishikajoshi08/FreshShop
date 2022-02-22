using FreshShop.Data;
using FreshShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FreshShopContext _context = null;
        public CategoryRepository(FreshShopContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            return await _context.Category.Select(x => new CategoryModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name

            }).ToListAsync();
        }
    }
}
