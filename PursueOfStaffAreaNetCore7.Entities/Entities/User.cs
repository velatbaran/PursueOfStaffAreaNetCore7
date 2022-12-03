using PursueOfStaffAreaNetCore7.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.Entities
{
    public class User : BaseEntity
    {
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

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
        [Compare(nameof(Password),ErrorMessage ="{0} field with {1} field doesn't match")]
        public string RePassword { get; set; }

        public string Role { get; set; }

        [DisplayName("Is Active?")]
        public bool IsActive { get; set; }= true;

        public virtual List<AllowRequest> AllowRequests { get; set; }

        public User()
        {
            AllowRequests = new List<AllowRequest>();
        }
    }
}
