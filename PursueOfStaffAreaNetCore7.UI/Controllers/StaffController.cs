using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
using System.Security.Claims;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IService<Department> _serviceDepartment;
        private readonly IService<Duty> _serviceDuty;
        private readonly IService<Profession> _serviceProfession;
        private readonly IService<EducationState> _serviceEducationState;
        private readonly IService<Degree> _serviceDegree;
        private readonly IService<StaffStatu> _serviceStaffStatu;
        private readonly IMapper _mapper;

        public StaffController(IService<Department> serviceDepartment, IService<Duty> serviceDuty, IService<Profession> serviceProfession, IService<EducationState> serviceEducationState, IStaffService staffService, IMapper mapper, IService<Degree> serviceDegree, IService<StaffStatu> serviceStaffStatu)
        {
            _serviceDepartment = serviceDepartment;
            _serviceDuty = serviceDuty;
            _serviceProfession = serviceProfession;
            _serviceEducationState = serviceEducationState;
            _staffService = staffService;
            _mapper = mapper;
            _serviceDegree = serviceDegree;
            _serviceStaffStatu = serviceStaffStatu;
        }

        public async Task<IActionResult> List()
        {
            List<ListStaffViewModel> listStaffViewModel = await _staffService.GetStaffsWithAllEntities();
            if (User.FindFirstValue(ClaimTypes.Role) == "admin")
            {
                return View(listStaffViewModel);
            }

            return View(listStaffViewModel.Where(x => x.Department.Name == User.FindFirstValue(ClaimTypes.Actor)).ToList());

        }

        //private async Task AddStaffDropdownlistEntities()
        //{
        //    ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name");
        //    ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name");
        //    ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name");
        //    ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name");
        //    ViewBag.Degrees = new SelectList(await _serviceDegree.GetAllAsync(), "Id", "Name");
        //    ViewBag.StaffStatus = new SelectList(await _serviceStaffStatu.GetAllAsync(), "Id", "Name");
        //}

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // ToDo List
            IEnumerable<Department> listDepartments = await _serviceDepartment.GetAllAsync();
            Department department = listDepartments.Where(x => x.Name == User.FindFirstValue(ClaimTypes.Actor)).FirstOrDefault();
            List<Department> departmentofUser = new List<Department> { department}.ToList();
            if (User.FindFirstValue(ClaimTypes.Role) == "admin")
            {
                ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name");
            }
            else
            {
                ViewBag.Departments = new SelectList(departmentofUser, "Id", "Name");
            }
            ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name");
            ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name");
            ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name");
            ViewBag.Degrees = new SelectList(await _serviceDegree.GetAllAsync(), "Id", "Name");
            ViewBag.StaffStatus = new SelectList(await _serviceStaffStatu.GetAllAsync(), "Id", "Name");
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

                    IEnumerable<Department> _listDepartments = await _serviceDepartment.GetAllAsync();
                    Department _department = _listDepartments.Where(x => x.Name == User.FindFirstValue(ClaimTypes.Actor)).FirstOrDefault();
                    List<Department> _departmentofUser = new List<Department> { _department }.ToList();
                    if (User.FindFirstValue(ClaimTypes.Role) == "admin")
                    {
                        ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name");
                    }
                    else
                    {
                        ViewBag.Departments = new SelectList(_departmentofUser, "Id", "Name");
                    }
                    ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name");
                    ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name");
                    ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name");
                    ViewBag.Degrees = new SelectList(await _serviceDegree.GetAllAsync(), "Id", "Name");
                    ViewBag.StaffStatus = new SelectList(await _serviceStaffStatu.GetAllAsync(), "Id", "Name");

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

                model.RegisteringUser = User.FindFirst("Username").Value;
                await _staffService.AddAsync(_mapper.Map<Staff>(model));
                TempData["resultStaff"] = "Staff created successfully";
                return RedirectToAction(nameof(List));
            }
 // ToDo List
            IEnumerable<Department> listDepartments = await _serviceDepartment.GetAllAsync();
            Department department = listDepartments.Where(x => x.Name == User.FindFirstValue(ClaimTypes.Actor)).FirstOrDefault();
            List<Department> departmentofUser = new List<Department> { department }.ToList();
            if (User.FindFirstValue(ClaimTypes.Role) == "admin")
            {
                ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name");
            }
            else
            {
                ViewBag.Departments = new SelectList(departmentofUser, "Id", "Name");
            }
            ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name");
            ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name");
            ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name");
            ViewBag.Degrees = new SelectList(await _serviceDegree.GetAllAsync(), "Id", "Name");
            ViewBag.StaffStatus = new SelectList(await _serviceStaffStatu.GetAllAsync(), "Id", "Name");

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
            // ToDo List
            IEnumerable<Department> listDepartments = await _serviceDepartment.GetAllAsync();
            Department department = listDepartments.Where(x => x.Name == User.FindFirstValue(ClaimTypes.Actor)).FirstOrDefault();
            List<Department> departmentofUser = new List<Department> { department }.ToList();
            if (User.FindFirstValue(ClaimTypes.Role) == "admin")
            {
                ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name",staff.DepartmentId);
            }
            else
            {
                ViewBag.Departments = new SelectList(departmentofUser, "Id", "Name",staff.DepartmentId);
            }
            ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name", staff.DutyId);
            ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name", staff.EducationStateId);
            ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name", staff.ProfessionId);
            ViewBag.Degrees = new SelectList(await _serviceDegree.GetAllAsync(), "Id", "Name",staff.DegreeId);
            ViewBag.StaffStatus = new SelectList(await _serviceStaffStatu.GetAllAsync(), "Id", "Name",staff.StaffStatuId);

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

                    // ToDo List
                    IEnumerable<Department> _listDepartments = await _serviceDepartment.GetAllAsync();
                    Department _department = _listDepartments.Where(x => x.Name == User.FindFirstValue(ClaimTypes.Actor)).FirstOrDefault();
                    List<Department> _departmentofUser = new List<Department> { _department }.ToList();
                    if (User.FindFirstValue(ClaimTypes.Role) == "admin")
                    {
                        ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name", staff.DepartmentId);
                    }
                    else
                    {
                        ViewBag.Departments = new SelectList(_departmentofUser, "Id", "Name", staff.DepartmentId);
                    }
                    ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name", staff.DutyId);
                    ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name", staff.EducationStateId);
                    ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name", staff.ProfessionId);
                    ViewBag.Degrees = new SelectList(await _serviceDegree.GetAllAsync(), "Id", "Name", staff.DegreeId);
                    ViewBag.StaffStatus = new SelectList(await _serviceStaffStatu.GetAllAsync(), "Id", "Name", staff.StaffStatuId);

                    return View(model);
                }

                model.RegisteringUser = User.FindFirst("Username").Value;
                await _staffService.UpdateAsync(_mapper.Map<Staff>(model));
                TempData["resultStaff"] = "Staff updated successfully";
                return RedirectToAction(nameof(List));
            }

            IEnumerable<Department> listDepartments = await _serviceDepartment.GetAllAsync();
            Department department = listDepartments.Where(x => x.Name == User.FindFirstValue(ClaimTypes.Actor)).FirstOrDefault();
            List<Department> departmentofUser = new List<Department> { department }.ToList();
            if (User.FindFirstValue(ClaimTypes.Role) == "admin")
            {
                ViewBag.Departments = new SelectList(await _serviceDepartment.GetAllAsync(), "Id", "Name", model.DepartmentId);
            }
            else
            {
                ViewBag.Departments = new SelectList(departmentofUser, "Id", "Name", model.DepartmentId);
            }
            ViewBag.Duties = new SelectList(await _serviceDuty.GetAllAsync(), "Id", "Name", model.DutyId);
            ViewBag.EducationStatus = new SelectList(await _serviceEducationState.GetAllAsync(), "Id", "Name", model.EducationStateId);
            ViewBag.Professions = new SelectList(await _serviceProfession.GetAllAsync(), "Id", "Name", model.ProfessionId);
            ViewBag.Degrees = new SelectList(await _serviceDegree.GetAllAsync(), "Id", "Name", model.DegreeId);
            ViewBag.StaffStatus = new SelectList(await _serviceStaffStatu.GetAllAsync(), "Id", "Name", model.StaffStatuId);

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

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            List<ListStaffViewModel> listStaff = await _staffService.GetStaffsWithAllEntities();
            var staff = listStaff.Where(x => x.Id == id).FirstOrDefault();
            if (staff == null)
            {
                throw new NotFoundException($"{id} nolu staff not found");
            }

            return View(_mapper.Map<Staff>(staff));
        }
    }
}
