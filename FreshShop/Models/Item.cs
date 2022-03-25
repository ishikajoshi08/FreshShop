using FreshShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Models
{
    public class Item
    {
        public Products Products { get; set; }

        public int Quantity { get; set; }
    }
}
