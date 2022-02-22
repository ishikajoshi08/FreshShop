using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FreshShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 4)]
        [Required(ErrorMessage ="Please enter Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter Product Description")]

        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Product Price")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Please enter Product Category")]
        public int CategoryId { get; set; }
        public string Category { get; set; }

        [Required(ErrorMessage = "Please upload Product Image")]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }

        [Required(ErrorMessage = "Please upload Product Gallery Image")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

    }
}
