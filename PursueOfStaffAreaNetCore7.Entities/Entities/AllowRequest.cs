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
    public class AllowRequest : BaseEntity
    {
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public int AllowTypeId { get; set; }
        public virtual AllowType AllowType { get; set; }

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

        [DisplayName("Confirming")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [DisplayName("Is Confirmed?")]
        public bool IsConfirmed { get; set; } = false;

        [DisplayName("Is Allowed?")]
        public bool IsAllowed { get; set; } = false;
    }
}
