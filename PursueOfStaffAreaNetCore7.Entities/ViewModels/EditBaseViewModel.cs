using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels
{
    public class EditBaseViewModel
    {
        public int Id { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string RegisteringUser { get; set; } = "system";
    }
}
