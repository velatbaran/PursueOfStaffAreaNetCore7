using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Staff;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Admin
{
    public class UserViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsLocked { get; set; } = true;
    }

    public class ListUserViewModel : UserViewModel
    {
        public ListStaffViewModel Staff { get; set; }
    }

    public class AddUserViewModel : AddBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Staff")]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Username { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address.")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        [Compare(nameof(Password), ErrorMessage = "{0} field with {1} field doesn't match")]
        public string RePassword { get; set; }

        public string Role { get; set; } = "standart";
    }
    public class EditUserViewModel : EditBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Staff")]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Username { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address.")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Email { get; set; }

        public string Role { get; set; } = "standart";

    }

    public class EditUserNameViewModel : EditBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Username { get; set; }
    }
    public class EditEmailViewModel : EditBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Email { get; set; }
    }
    public class EditRoleViewModel : EditBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Role { get; set; }
    }
    public class EditPasswordViewModel : EditBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        [Compare(nameof(Password), ErrorMessage = "{0} field with {1} field doesn't match")]
        public string RePassword { get; set; }
    }
}
