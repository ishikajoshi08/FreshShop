using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Models
{
    public class ContactFormModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Message")]
        public string Message { get; set; }
    }
}
