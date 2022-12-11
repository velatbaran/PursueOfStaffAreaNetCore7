using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Exceptions;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Department;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Duty;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.EducationState;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Profession;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Staff;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IService<Department> _serviceDepartment;
        private readonly IService<Duty> _serviceDuty;
        private readonly IService<Profession> _serviceProfession;
        private readonly IService<EducationState> _serviceEducationState;
        private readonly IMapper _mapper;

        public StaffController(IService<Department> serviceDepartment, IService<Duty> serviceDuty, IService<Profession> serviceProfession, IService<EducationState> serviceEducationState, IStaffService staffService, IMapper mapper)
        {
            _serviceDepartment = serviceDepartment;
            _serviceDuty = serviceDuty;
            _serviceProfession = serviceProfession;
            _serviceEducationState = serviceEducationState;
            _staffService = staffService;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {
            return View(await _staffService.GetStaffsWithAllEntities());
        }

        private async Task AddStaffDropdownlistEntities()
        {
            ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name");
            ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name");
            ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name");
            ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddStaffDropdownlistEntities();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddStaffViewModel model, IFormFile ProfileImage)
        {
            if (ModelState.IsValid)
            {
                if (await _staffService.AnyAsync(x => x.TC == model.TC))
                {
                    ModelState.AddModelError(model.TC, $"{model.TC} no was recorded already");
                    AddStaffDropdownlistEntities();
                    return View(model);
                }

                if (ProfileImage != null)
                {
                    string fileName = $"img_{model.TC}.{ProfileImage.ContentType.Split('/')[1]}";   // image/png   image/jpg
                    Stream stream = new FileStream($"wwwroot/uploads/img/staffs/{fileName}", FileMode.OpenOrCreate);
                    ProfileImage.CopyTo(stream);
                    stream.Close();
                    stream.Dispose();
                    model.ProfileImage = fileName;
                }
                else
                {
                    model.ProfileImage = "no-image.jpg";
                }

                await _staffService.AddAsync(_mapper.Map<Staff>(model));
                TempData["resultStaff"] = "Staff created successfully";
                return RedirectToAction(nameof(List));
            }
            AddStaffDropdownlistEntities();
            return View(model);
        }

        //private async Task EditDropDownListLoader(EditStaffViewModel model)
        //{
        //    ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name", model.DepartmentId);
        //    ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name", model.DutyId);
        //    ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name", model.EducationStateId);
        //    ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name", model.ProfessionId);
        //}

        //private async Task EditDropDownListLoader2(Staff staff)
        //{
        //    ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name", staff.DepartmentId);
        //    ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name", staff.DutyId);
        //    ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name", staff.EducationStateId);
        //    ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name", staff.ProfessionId);
        //}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var staff = await _staffService.GetByIdAsync(id);
            if (staff == null)
            {
                throw new NotFoundException($"{id} nolu staff not found");
            }

            ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name", staff.DepartmentId);
            ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name", staff.DutyId);
            ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name", staff.EducationStateId);
            ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name", staff.ProfessionId);

            return View(_mapper.Map<EditStaffViewModel>(staff));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditStaffViewModel model,IFormFile ProfileImage)
        {
            if (ModelState.IsValid)
            {
                Staff staff = await _staffService.GetByIdAsync(model.Id);
                if (ProfileImage != null)
                {
                    string fileName = $"img_{staff.TC}.{ProfileImage.ContentType.Split('/')[1]}";   // image/png   image/jpg
                    Stream stream = new FileStream($"wwwroot/uploads/img/staffs/{fileName}", FileMode.OpenOrCreate);
                    ProfileImage.CopyTo(stream);
                    stream.Close();
                    stream.Dispose();
                    model.ProfileImage = fileName;
                }

                if (await _staffService.AnyAsync(x => x.TC == model.TC && x.TC != staff.TC))
                {
                    ModelState.AddModelError(model.TC, $"{model.TC} TC no was recorded already");

                    ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name", staff.DepartmentId);
                    ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name", staff.DutyId);
                    ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name", staff.EducationStateId);
                    ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name", staff.ProfessionId);

                    return View(model);
                }

                await _staffService.UpdateAsync(_mapper.Map<Staff>(model));
                TempData["resultStaff"] = "Staff updated successfully";
                return RedirectToAction(nameof(List));
            }

            ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name", model.DepartmentId);
            ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name", model.DutyId);
            ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name", model.EducationStateId);
            ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name", model.ProfessionId);

            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            Staff staff = await _staffService.GetByIdAsync(id);
            if (staff == null)
            {
                throw new NotFoundException($"({id}) nolu staff not found");
            }
            await _staffService.RemoveAsync(staff);
            TempData["resultStaff"] = "Staff removed successfully";
            return RedirectToAction(nameof(List));
        }
    }
}
