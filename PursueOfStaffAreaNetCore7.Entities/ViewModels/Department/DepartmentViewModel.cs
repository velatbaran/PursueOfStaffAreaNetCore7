using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Department
{
    public class DepartmentViewModel : BaseViewModel
    {
        public string Name { get; set; }
    }

    public class AddDepartmentViewModel : AddBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Name { get; set; }
    }

    public class EditDepartmentViewModel : EditBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Name { get; set; }
    }
}
