using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.Entities
{
    public class Duty : BaseEntity
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Name { get; set; }

        public virtual List<Staff> Staffs { get; set; }
        public Duty()
        {
            Staffs = new List<Staff>();
        }
    }
}
