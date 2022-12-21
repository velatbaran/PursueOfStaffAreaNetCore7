using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Password { get; set; }
    }
}
