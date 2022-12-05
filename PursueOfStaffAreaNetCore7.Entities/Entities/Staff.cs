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
    public class Staff : BaseEntity
    {

        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(11, ErrorMessage = "{0} field must be the most {1} character")]
        public string TC { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string FullName { get; set; }

        [DisplayName("Born Date")]
        [DataType(DataType.DateTime)]
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
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayName("Exit Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? ExitDate { get; set; }

        [DisplayName("Total Working Year")]
        public int TotalWorkingYear { get; set; }

        [DisplayName("Total Allow Day")]
        public int TotalAllowDay { get; set; }

        [DisplayName("Used Day")]
        public int UsedDay { get; set; }

        [DisplayName("Remain Day")]
        public int RemainDay { get; set; }

        [DisplayName("Is State Working?")]
        public bool IsStateWorking { get; set; } = true;

        public string Description { get; set; }

        [DisplayName("Is Deleted?")]
        public bool IsDeleted { get; set; } = false;

        [DisplayName("Is Duty Assigned?")]
        public bool IsDutyAssigned { get; set; } = false;

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int EducationId { get; set; }
        public virtual EducationState EducationState { get; set; }

        public int ProfessionId { get; set; }
        public virtual Profession Profession { get; set; }

        public int DutyId { get; set; }
        public virtual Duty Duty { get; set; }

        public virtual List<Area> Areas { get; set; }
        public virtual List<DutyAssign> DutyAssigns { get; set; }
        public virtual List<AllowRequest> AllowRequests { get; set; }
        public Staff()
        {
            Areas = new List<Area>();
            DutyAssigns = new List<DutyAssign>();
            AllowRequests = new List<AllowRequest>();
        }
    }
}
