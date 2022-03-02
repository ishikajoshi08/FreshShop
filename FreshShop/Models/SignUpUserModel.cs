using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression("[a-zA-Z]+",ErrorMessage ="Only alphabets allowed!")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your Confirm Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
