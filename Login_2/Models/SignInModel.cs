using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Login_2.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Email is required")]
        
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
