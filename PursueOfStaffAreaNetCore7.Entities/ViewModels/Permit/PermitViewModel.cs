using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Permit
{
    public class ListPermitViewModel : BaseViewModel
    {
        public string TC { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int TotalAllowDay { get; set; }
        public int UsedDay { get; set; }
        public int RemainDay { get; set; }
    }

    public class AddPermitViewModel : AddBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(11, ErrorMessage = "{0} field must be the most {1} character")]
        public string TC { get; set; }

        [DisplayName("Total Allow Day")]
        public int TotalAllowDay { get; set; }

        [DisplayName("Used Day")]
        public int UsedDay { get; set; }

        [DisplayName("Remain Day")]
        public int RemainDay { get; set; }

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
    }

    public class EditPermitViewModel : EditBaseViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(11, ErrorMessage = "{0} field must be the most {1} character")]
        public string TC { get; set; }

        [DisplayName("Total Allow Day")]
        public int TotalAllowDay { get; set; }

        [DisplayName("Used Day")]
        public int UsedDay { get; set; }

        [DisplayName("Remain Day")]
        public int RemainDay { get; set; }

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
    }
}
