using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kefisinventory.Models
{
    public class Loginviewmodel
    {
        [Required(ErrorMessage = "Email Address is required!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address")]
        [Display(Name = "Email Address")]
        public string Emailaddress { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password, ErrorMessage = "Enter a valid password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
