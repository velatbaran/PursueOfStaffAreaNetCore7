using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Area
{
    public class AreaViewModel : BaseViewModel
    {
        public string Name { get; set; }
    }

    public class ListAreaViewModel : AreaViewModel
    {
        public ListStaffViewModel Staff { get; set; }
    }

    public class AddAreaViewModel : AddBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Name { get; set; }

        [DisplayName("Chief")]
        [Required(ErrorMessage = "{0} field not be null")]
        public int StaffId { get; set; }
    }
}
