using AutoMapper;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.AllowType;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Department;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Duty;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Profession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.BusinnessLayer.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {   // allowtype
            CreateMap<AllowType,AddAllowTypeViewModel>().ReverseMap();
            CreateMap<AllowType,EditAllowTypeViewModel>().ReverseMap();
            // department
            CreateMap<Department,AddDepartmentViewModel>().ReverseMap();
            CreateMap<Department,EditDepartmentViewModel>().ReverseMap();
            // profession
            CreateMap<Profession, AddProfessionViewModel>().ReverseMap();
            CreateMap<Profession, EditProfessionViewModel>().ReverseMap();
            // duty
            CreateMap<Duty, AddDutyViewModel>().ReverseMap();
            CreateMap<Duty, EditDutyViewModel>().ReverseMap();
        } 
    }
}
