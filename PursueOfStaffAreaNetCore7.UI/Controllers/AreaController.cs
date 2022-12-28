using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Concrete;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Exceptions;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Area;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Staff;
using System.Security.Claims;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    [Authorize]
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;

        public AreaController(IAreaService areaService, IMapper mapper, IStaffService staffService)
        {
            _areaService = areaService;
            _mapper = mapper;
            _staffService = staffService;
        }
        public async Task<IActionResult> List()
        {
            return View(await _areaService.GetAreasWithStaff());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            List<ListStaffViewModel> listStaffViewModel = await _staffService.GetStaffsWithAllEntities();
            List<ListStaffViewModel> _listStaffViewModel = null; ;
            if (User.FindFirstValue(ClaimTypes.Role) == "admin")
            {
                _listStaffViewModel = listStaffViewModel;
            }
            else
            {
                _listStaffViewModel = listStaffViewModel.Where(x => x.Department.Name == User.FindFirstValue(ClaimTypes.Actor)).ToList();
            }
            List<SelectListItem> staffList = (from s in _listStaffViewModel
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();
            ViewBag.Staffs = staffList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RegisteringUser = User.FindFirst("Username").Value;
                await _areaService.AddAsync(_mapper.Map<Area>(model));
                TempData["resultArea"] = "Area created successfully";
                return RedirectToAction(nameof(List));
            }

            List<ListStaffViewModel> listStaffViewModel = await _staffService.GetStaffsWithAllEntities();
            List<ListStaffViewModel> _listStaffViewModel = null; ;
            if (User.FindFirstValue(ClaimTypes.Role) == "admin")
            {
                _listStaffViewModel = listStaffViewModel;
            }
            else
            {
                _listStaffViewModel = listStaffViewModel.Where(x => x.Department.Name == User.FindFirstValue(ClaimTypes.Actor)).ToList();
            }
            List<SelectListItem> staffList = (from s in _listStaffViewModel
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();
            ViewBag.Staffs = staffList;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Area area = await _areaService.GetByIdAsync(id);
            if (area == null)
            {
                throw new NotFoundException($"{id} nolu area not found");
            }

            List<ListStaffViewModel> listStaffViewModel = await _staffService.GetStaffsWithAllEntities();
            List<ListStaffViewModel> _listStaffViewModel = null; ;
            if (User.FindFirstValue(ClaimTypes.Role) == "admin")
            {
                _listStaffViewModel = listStaffViewModel;
            }
            else
            {
                _listStaffViewModel = listStaffViewModel.Where(x => x.Department.Name == User.FindFirstValue(ClaimTypes.Actor)).ToList();
            }
            List<SelectListItem> staffList = (from s in _listStaffViewModel
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();
            ViewBag.Staffs = staffList;
            return View(_mapper.Map<EditAreaViewModel>(area)) ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RegisteringUser = User.FindFirst("Username").Value;
                await _areaService.UpdateAsync(_mapper.Map<Area>(model));
                TempData["resultArea"] = "Area updated successfully";
                return RedirectToAction(nameof(List));
            }

            List<ListStaffViewModel> listStaffViewModel = await _staffService.GetStaffsWithAllEntities();
            List<ListStaffViewModel> _listStaffViewModel = null; ;
            if (User.FindFirstValue(ClaimTypes.Role) == "admin")
            {
                _listStaffViewModel = listStaffViewModel;
            }
            else
            {
                _listStaffViewModel = listStaffViewModel.Where(x => x.Department.Name == User.FindFirstValue(ClaimTypes.Actor)).ToList();
            }
            List<SelectListItem> staffList = (from s in _listStaffViewModel
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();
            ViewBag.Staffs = staffList;
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            Area area = await _areaService.GetByIdAsync(id);
            if (area == null)
            {
                throw new NotFoundException($"({id}) nolu area not found");
            }

            await _areaService.RemoveAsync(area);
            TempData["resultArea"] = "Area removed successfully";
            return RedirectToAction(nameof(List));
        }
    }
}
