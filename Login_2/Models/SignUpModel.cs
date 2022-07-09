using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Login_2.Models
{
    public class SignUpModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Mobile field is required")]
        public string Mobile { get; set; }
        [Required(ErrorMessage ="Location field is required")]
        public string Location { get; set; }
        [Required(ErrorMessage ="Email field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password miss match")]
        public string ComfirmPassword { get; set; }
    }
}
