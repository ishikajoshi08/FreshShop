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
        public int OId { get; set; }
        [Display(Name="Order")]
        public int OrderId { get; set; }
        [Display(Name = "Product")]
        public int  Id{ get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("Id")]
        public Products Products { get; set; }
    }
}
