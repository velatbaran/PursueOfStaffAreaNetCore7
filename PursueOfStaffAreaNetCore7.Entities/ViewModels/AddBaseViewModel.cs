using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels
{
    public class AddBaseViewModel
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string RegisteringUser { get; set; } = "system";
    }
}
