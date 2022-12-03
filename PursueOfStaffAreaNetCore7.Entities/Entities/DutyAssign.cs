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
    public class DutyAssign : BaseEntity
    {
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }

        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Week Vacation")]
        public string WeekVacation { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [DisplayName("Duty Description")]
        public string Description { get; set; }

        [DisplayName("Is Active?")]
        public bool IsActive { get; set; } = true;
    }
}
