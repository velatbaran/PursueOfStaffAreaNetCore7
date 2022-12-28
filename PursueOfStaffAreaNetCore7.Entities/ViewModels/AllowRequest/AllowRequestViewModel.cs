using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Admin;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.AllowType;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Allow
{
    public class AllowRequestViewModel : BaseViewModel
    {
        public int HowManyDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IsConfirmed { get; set; }
        public bool IsAllowed { get; set; } = false;
    }

    public class ListAllowRequestViewModel : AllowRequestViewModel
    {
        public ListStaffViewModel Staff { get; set; }
        public AllowTypeViewModel AllowType { get; set; }
        public ListUserViewModel User { get; set; }
    }

    public class AddAllowRequestViewModel : AddBaseViewModel
    {
        [DisplayName("Staff")]
        public int StaffId { get; set; }

        [DisplayName("Allow Type")]
        public int AllowTypeId { get; set; }

        [DisplayName("How many days?")]
        [Required(ErrorMessage = "{0} field not be null")]
        public int HowManyDays { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EndDate { get; set; }

        public string IsConfirmed { get; set; } = "pending";

        [DisplayName("Confirming User")]
        public int UserId { get; set; }

    }

    public class EditAllowRequestViewModel : EditBaseViewModel
    {
        [DisplayName("Staff")]
        public int StaffId { get; set; }

        [DisplayName("Allow Type")]
        public int AllowTypeId { get; set; }

        [DisplayName("How many days?")]
        [Required(ErrorMessage = "{0} field not be null")]
        public int HowManyDays { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EndDate { get; set; }

        public string IsConfirmed { get; set; } = "pending";

        [DisplayName("Confirming User")]
        public int UserId { get; set; }
    }
}
