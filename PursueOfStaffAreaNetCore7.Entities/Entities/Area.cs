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
    public class Area : BaseEntity
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Name { get; set; }

        [DisplayName("Chief")]
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public virtual List<DutyAssign> DutyAssigns{ get; set; }
        public Area()
        {
            DutyAssigns = new List<DutyAssign>();
        }
    }
}
