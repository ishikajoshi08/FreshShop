using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Data
{
    public class FreshShopContext : DbContext
    {
        public FreshShopContext(DbContextOptions<FreshShopContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
    }
}
