using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Degree;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Department;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Duty;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.EducationState;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Profession;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.StaffStatu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Staff
{
    public class StaffViewModel : BaseViewModel
    {
        public string TC { get; set; }
        public string FullName { get; set; }
        public DateTime BornDate { get; set; }
        public string Phone { get; set; }
        public string ProfileImage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public string Description { get; set; }
        public bool IsStateWorking { get; set; }
        public int TotalWorkingYear { get; set; }
        public int TotalAllowDay { get; set; }
        public int UsedDay { get; set; }
        public int RemainDay { get; set; }
        public bool IsDutyAssigned { get; set; } = false;
    }
    public class ListStaffViewModel : StaffViewModel
    {
        public DutyViewModel Duty { get; set; }
        public EducationStateViewModel EducationState { get; set; }
        public ProfessionViewModel Profession { get; set; }
        public DepartmentViewModel Department { get; set; }
        public DegreeViewModel Degree { get; set; }
        public StaffStatuViewModel StaffStatu { get; set; }
    }
    public class AddStaffViewModel : AddBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(11, ErrorMessage = "{0} field must be the most {1} character")]
        public string TC { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string FullName { get; set; }

        [DisplayName("Born Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime BornDate { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(11, ErrorMessage = "{0} field must be the most {1} character")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [DisplayName("Profile Image")]
        public string ProfileImage { get; set; } = "no-image.jpg";

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [DisplayName("Education")]
        public int EducationStateId { get; set; }

        [DisplayName("Profession")]
        public int ProfessionId { get; set; }

        [DisplayName("Duty")]
        public int DutyId { get; set; }

        [DisplayName("Staff Statu")]
        public int StaffStatuId { get; set; }

        [DisplayName("Degree")]
        public int DegreeId { get; set; }
    }
    public class EditStaffViewModel : EditBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(11, ErrorMessage = "{0} field must be the most {1} character")]
        public string TC { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string FullName { get; set; }

        [DisplayName("Profile Image")]
        public string ProfileImage { get; set; } = "no-image.jpg";

        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(11, ErrorMessage = "{0} field must be the most {1} character")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [DisplayName("Born Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime BornDate { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "{0} field not be null")]
        public int DepartmentId { get; set; }

        [DisplayName("Education")]
        [Required(ErrorMessage = "{0} field not be null")]
        public int EducationStateId { get; set; }

        [DisplayName("Profession")]
        [Required(ErrorMessage = "{0} field not be null")]
        public int ProfessionId { get; set; }

        [DisplayName("Duty")]
        [Required(ErrorMessage = "{0} field not be null")]
        public int DutyId { get; set; }

        [DisplayName("Staff Statu")]
        public int StaffStatuId { get; set; }

        [DisplayName("Degree")]
        public int DegreeId { get; set; }
    }

}
