﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Profession
{
    public class ProfessionViewModel
    {
    }

    public class AddProfessionViewModel
    {
        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

    public class EditProfessionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} field not be null")]
        [StringLength(50, ErrorMessage = "{0} field must be the most {1} character")]
        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}