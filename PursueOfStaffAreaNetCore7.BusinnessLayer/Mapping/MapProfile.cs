using AutoMapper;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.AllowType;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Area;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Department;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Duty;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.EducationState;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Profession;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Staff;
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
            CreateMap<AllowType,AllowTypeViewModel>().ReverseMap();
            CreateMap<AllowType,AddAllowTypeViewModel>().ReverseMap();
            CreateMap<AllowType,EditAllowTypeViewModel>().ReverseMap();
            // department
            CreateMap<Department,DepartmentViewModel>().ReverseMap();
            CreateMap<Department,AddDepartmentViewModel>().ReverseMap();
            CreateMap<Department,EditDepartmentViewModel>().ReverseMap();
            // educationstate
            CreateMap<EducationState, EducationStateViewModel>().ReverseMap();
            // profession
            CreateMap<Profession, ProfessionViewModel>().ReverseMap();
            CreateMap<Profession, AddProfessionViewModel>().ReverseMap();
            CreateMap<Profession, EditProfessionViewModel>().ReverseMap();
            // duty
            CreateMap<Duty, DutyViewModel>().ReverseMap();
            CreateMap<Duty, AddDutyViewModel>().ReverseMap();
            CreateMap<Duty, EditDutyViewModel>().ReverseMap();
            //staff
            CreateMap<Staff, ListStaffViewModel>().ReverseMap();
            CreateMap<Staff, AddStaffViewModel>().ReverseMap();
            CreateMap<Staff, EditStaffViewModel>().ReverseMap();
            // area
            CreateMap<Area, ListAreaViewModel>().ReverseMap();
            CreateMap<Area, AddAreaViewModel>().ReverseMap();
        } 
    }
}
