using FreshShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Models
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        [Display(Name="Order")]
        public int OrderId { get; set; }
        [Display(Name = "Product")]
        public int  Id{ get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        [ForeignKey("Id")]
        public virtual Products Products { get; set; }
    }
}
