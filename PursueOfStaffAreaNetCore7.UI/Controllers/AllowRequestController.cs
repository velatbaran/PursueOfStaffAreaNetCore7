using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Concrete;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Exceptions;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Admin;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Allow;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Staff;
using System.Security.Claims;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    public class AllowRequestController : Controller
    {
        private readonly IAllowRequestService _allowRequestService;
        private readonly IStaffService _staffService;
        private readonly IUserService _userService;
        private readonly IService<AllowType> _serviceAllowType;
        private readonly IMapper _mapper;

        public AllowRequestController(IAllowRequestService allowRequestService, IMapper mapper, IStaffService staffService, IService<AllowType> serviceAllowType, IUserService userService)
        {
            _allowRequestService = allowRequestService;
            _mapper = mapper;
            _staffService = staffService;
            _serviceAllowType = serviceAllowType;
            _userService = userService;
        }

        public async Task<IActionResult> List()
        {
            return View(await _allowRequestService.GetAllowRequestsWithAllEntities());
        }

        private async Task ShowDropDownLists()
        {
            List<ListStaffViewModel> listStaffViewModel = await _staffService.GetStaffsWithAllEntities();
            List<ListUserViewModel> listUserViewModel = await _userService.GetUsersWithStaff();
            List<ListStaffViewModel> _listStaffViewModel = null;
            List<ListUserViewModel> _listUserViewModel = null;
            if (User.IsInRole("admin"))
            {
                _listStaffViewModel = listStaffViewModel.Where(x=> x.IsStateWorking == true).ToList();
                _listUserViewModel = listUserViewModel.Where(x=>x.IsLocked == false && (x.Staff.Degree.Name == "Amir" || x.Staff.Degree.Name == "Şef" || x.Staff.Degree.Name == "Müdür")).ToList();
            }
            else
            {
                _listStaffViewModel = listStaffViewModel.Where(x => x.Department.Name == User.FindFirstValue(ClaimTypes.Actor) && x.IsStateWorking == true).ToList();
                _listUserViewModel = listUserViewModel.Where(x => x.Staff.Department.Name == User.FindFirstValue(ClaimTypes.Actor) && (x.Staff.Degree.Name == "Amir" || x.Staff.Degree.Name == "Şef" || x.Staff.Degree.Name == "Müdür") && x.IsLocked == false).ToList();
            }

            List<SelectListItem> staffList = (from s in _listStaffViewModel
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();

            List<SelectListItem> userConfirmingList = (from s in _listUserViewModel
                                                       select new SelectListItem
                                                       {
                                                           Text = s.Staff.FullName,
                                                           Value = s.Id.ToString()
                                                       }).ToList();

            List<SelectListItem> allowTypeList = (from a in await _serviceAllowType.GetAllAsync()
                                                  select new SelectListItem
                                                  {
                                                      Text = a.Name,
                                                      Value = a.Id.ToString()
                                                  }).ToList();

            ViewBag.Staffs = staffList;
            ViewBag.UsersConfirming = userConfirmingList;
            ViewBag.AllowTypes = allowTypeList;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //ShowDropDownLists();
            List<ListStaffViewModel> listStaffViewModel = await _staffService.GetStaffsWithAllEntities();
            List<ListUserViewModel> listUserViewModel = await _userService.GetUsersWithStaff();
            List<ListStaffViewModel> _listStaffViewModel = null;
            List<ListUserViewModel> _listUserViewModel = null;
            if (User.IsInRole("admin"))
            {
                _listStaffViewModel = listStaffViewModel.Where(x => x.IsStateWorking == true).ToList();
                _listUserViewModel = listUserViewModel.Where(x => x.IsLocked == false && (x.Staff.Degree.Name == "Amir" || x.Staff.Degree.Name == "Şef" || x.Staff.Degree.Name == "Müdür")).ToList();
            }
            else
            {
                _listStaffViewModel = listStaffViewModel.Where(x => x.Department.Name == User.FindFirstValue(ClaimTypes.Actor) && x.IsStateWorking == true).ToList();
                _listUserViewModel = listUserViewModel.Where(x => x.Staff.Department.Name == User.FindFirstValue(ClaimTypes.Actor) && (x.Staff.Degree.Name == "Amir" || x.Staff.Degree.Name == "Şef" || x.Staff.Degree.Name == "Müdür") && x.IsLocked == false).ToList();
            }

            List<SelectListItem> staffList = (from s in _listStaffViewModel
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();

            List<SelectListItem> userConfirmingList = (from s in _listUserViewModel
                                                       select new SelectListItem
                                                       {
                                                           Text = s.Staff.FullName,
                                                           Value = s.Id.ToString()
                                                       }).ToList();

            List<SelectListItem> allowTypeList = (from a in await _serviceAllowType.GetAllAsync()
                                                  select new SelectListItem
                                                  {
                                                      Text = a.Name,
                                                      Value = a.Id.ToString()
                                                  }).ToList();

            ViewBag.Staffs = staffList;
            ViewBag.UsersConfirming = userConfirmingList;
            ViewBag.AllowTypes = allowTypeList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddAllowRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<ListStaffViewModel> staffList = await _staffService.GetStaffsWithAllEntities();
                var staff = staffList.Where(x => x.Id == model.StaffId).FirstOrDefault();
                if (staff.TotalAllowDay == 0 || staff.RemainDay == 0 || (model.HowManyDays > staff.RemainDay))
                {
                    if (staff.TotalAllowDay == 0 || staff.RemainDay == 0)
                        ModelState.AddModelError("", "There is not allow of the staff now");
                    else if (model.HowManyDays > staff.RemainDay)
                        ModelState.AddModelError("", "Requested allow is more than remaining allow");
                }
                else
                {
                    //staff.UsedDay = staff.UsedDay + model.HowManyDays;
                    //staff.RemainDay = staff.TotalAllowDay - staff.UsedDay;

                    model.RegisteringUser = User.FindFirst("Username").Value;
                    await _allowRequestService.AddAsync(_mapper.Map<AllowRequest>(model));
                    //await _staffService.UpdateAsync(_mapper.Map<Staff>(staff));
                    TempData["resultAllowRequest"] = "AllowRequest created successfully";
                    return RedirectToAction(nameof(List));
                }
            }

            ShowDropDownLists();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //ShowDropDownLists();
            AllowRequest allowRequest = await _allowRequestService.GetByIdAsync(id);
            if (allowRequest == null)
            {
                throw new NotFoundException($"({id}) nolu staff not found");
            }

            List<ListStaffViewModel> listStaffViewModel = await _staffService.GetStaffsWithAllEntities();
            List<ListUserViewModel> listUserViewModel = await _userService.GetUsersWithStaff();
            List<ListStaffViewModel> _listStaffViewModel = null;
            List<ListUserViewModel> _listUserViewModel = null;
            if (User.IsInRole("admin"))
            {
                _listStaffViewModel = listStaffViewModel.Where(x => x.IsStateWorking == true).ToList();
                _listUserViewModel = listUserViewModel.Where(x => x.IsLocked == false && (x.Staff.Degree.Name == "Amir" || x.Staff.Degree.Name == "Şef" || x.Staff.Degree.Name == "Müdür")).ToList();
            }
            else
            {
                _listStaffViewModel = listStaffViewModel.Where(x => x.Department.Name == User.FindFirstValue(ClaimTypes.Actor) && x.IsStateWorking == true).ToList();
                _listUserViewModel = listUserViewModel.Where(x => x.Staff.Department.Name == User.FindFirstValue(ClaimTypes.Actor) && (x.Staff.Degree.Name == "Amir" || x.Staff.Degree.Name == "Şef" || x.Staff.Degree.Name == "Müdür") && x.IsLocked == false).ToList();
            }

            List<SelectListItem> staffList = (from s in _listStaffViewModel
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();

            List<SelectListItem> userConfirmingList = (from s in _listUserViewModel
                                                       select new SelectListItem
                                                       {
                                                           Text = s.Staff.FullName,
                                                           Value = s.Id.ToString()
                                                       }).ToList();

            List<SelectListItem> allowTypeList = (from a in await _serviceAllowType.GetAllAsync()
                                                  select new SelectListItem
                                                  {
                                                      Text = a.Name,
                                                      Value = a.Id.ToString()
                                                  }).ToList();

            ViewBag.Staffs = staffList;
            ViewBag.UsersConfirming = userConfirmingList;
            ViewBag.AllowTypes = allowTypeList;
            return View(_mapper.Map<EditAllowRequestViewModel>(allowRequest));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAllowRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<ListStaffViewModel> staffList = await _staffService.GetStaffsWithAllEntities();
                var staff = staffList.Where(x => x.Id == model.StaffId).FirstOrDefault();
                if (staff.TotalAllowDay == 0 || staff.RemainDay == 0 || (model.HowManyDays > staff.RemainDay))
                {
                    if (staff.TotalAllowDay == 0 || staff.RemainDay == 0)
                        ModelState.AddModelError("", "There is not allow of the staff now");
                    else if (model.HowManyDays > staff.RemainDay)
                        ModelState.AddModelError("", "Requested allow is more than remaining allow");
                }
                else
                {
                    //staff.UsedDay = staff.UsedDay + model.HowManyDays;
                    //staff.RemainDay = staff.TotalAllowDay - staff.UsedDay;

                    model.RegisteringUser = User.FindFirst("Username").Value;
                    await _allowRequestService.UpdateAsync(_mapper.Map<AllowRequest>(model));
                    //await _staffService.UpdateAsync(_mapper.Map<Staff>(staff));
                    TempData["resultAllowRequest"] = "AllowRequest updated successfully";
                    return RedirectToAction(nameof(List));
                }
            }

            ShowDropDownLists();
            return View(model);
        }

        public async Task<IActionResult> ApproveAllow(int id)
        {
            var _allowRequest = await _allowRequestService.GetByIdAsync(id);
            var _staff = await _staffService.GetByIdAsync(_allowRequest.StaffId);
            if (_allowRequest == null) throw new NotFoundException($"({id}) nolu allowRequest not found");
            _staff.UsedDay += _allowRequest.HowManyDays;
            _staff.RemainDay = _staff.TotalAllowDay - _staff.UsedDay;

            _allowRequest.IsConfirmed = "approved";
            _allowRequest.IsAllowed = true;
            _allowRequest.RegisteringUser = User.FindFirst("Username").Value; // ToDo List

            await _staffService.UpdateAsync(_staff);
            await _allowRequestService.UpdateAsync(_allowRequest);

            TempData["resultAllowRequest"] = "AllowRequest approved successfully";
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> RejectAllow(int id)
        {
            var _allowRequest = await _allowRequestService.GetByIdAsync(id);
            if (_allowRequest == null) throw new NotFoundException($"({id}) nolu allowRequest not found");

            _allowRequest.IsConfirmed = "rejected";
            _allowRequest.RegisteringUser = User.FindFirst("Username").Value; // ToDo List

            await _allowRequestService.UpdateAsync(_allowRequest);

            TempData["resultAllowRequest"] = "AllowRequest rejected successfully";
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Remove(int id)
        {
            AllowRequest allowRequest = await _allowRequestService.GetByIdAsync(id);
            if (allowRequest == null)
            {
                throw new NotFoundException($"({id}) nolu staff not found");
            }

            await _allowRequestService.RemoveAsync(allowRequest);
            TempData["resultAllowRequest"] = "AllowRequest removed successfully";
            return RedirectToAction(nameof(List));
        }
    }
}
