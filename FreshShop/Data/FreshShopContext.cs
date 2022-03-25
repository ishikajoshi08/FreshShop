using FreshShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Data
{
    public class FreshShopContext : IdentityDbContext<ApplicationUser>
    {
        public FreshShopContext(DbContextOptions<FreshShopContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }

        public DbSet<ProductGallery> ProductGallery { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
