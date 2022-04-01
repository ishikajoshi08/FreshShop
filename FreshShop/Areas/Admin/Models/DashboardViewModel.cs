using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int products_count { get; set; }
        public int users_count { get; set; }
        public int category_count { get; set; }
    }
}
