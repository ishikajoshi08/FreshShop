using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Data
{
    public class Products
    {        
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductGallery> productGallery { get; set; }
    }
}
