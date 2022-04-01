using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Only alphabets allowed!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [Display(Name = "City")]
        public string City { get; set; }
    }
}
