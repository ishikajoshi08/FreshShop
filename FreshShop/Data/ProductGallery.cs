using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Data
{
    public class ProductGallery
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public Products Product { get; set; }
    }
}
