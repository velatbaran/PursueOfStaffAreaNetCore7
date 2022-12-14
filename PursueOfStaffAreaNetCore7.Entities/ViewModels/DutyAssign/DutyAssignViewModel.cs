using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Area;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Staff;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.DutyAssign
{
    public class DutyAssignViewModel : BaseViewModel
    {
        public string WeekVacation { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class ListDutyAssignViewModel : DutyAssignViewModel
    {
        public ListAreaViewModel Area { get; set; }
        public ListStaffViewModel Staff { get; set; }
    }

    public class AddDutyAssignViewModel : AddBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Area")]
        public int AreaId { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Staff")]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Week Vacation")]
        public string WeekVacation { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Duty Description")]
        public string Description { get; set; }
    }

    public class EditDutyAssignViewModel : EditBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Area")]
        public int AreaId { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Staff")]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Week Vacation")]
        public string WeekVacation { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Duty Description")]
        public string Description { get; set; }

    }
}
