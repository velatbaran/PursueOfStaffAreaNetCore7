using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Concrete;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Exceptions;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.DutyAssign;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    public class DutyAssignController : Controller
    {
        private readonly IDutyAssignService _dutyAssignService;
        private readonly IStaffService _staffService;
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;

        public DutyAssignController(IDutyAssignService dutyAssignService, IMapper mapper, IAreaService areaService, IStaffService staffService)
        {
            _dutyAssignService = dutyAssignService;
            _mapper = mapper;
            _areaService = areaService;
            _staffService = staffService;
        }
        // ToDo List : IsActive process = with javascript,jquery
        public async Task<IActionResult> List()
        {
            return View(await _dutyAssignService.GetDutyAssignsWithStaffAndArea());
        }

        private async Task DropDownListLoader()
        {
            List<SelectListItem> staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();

            List<SelectListItem> areaList = (from s in await _areaService.GetAreasWithStaff()
                                             select new SelectListItem
                                             {
                                                 Text = s.Name,
                                                 Value = s.Id.ToString()
                                             }).ToList();
            ViewBag.Staffs = staffList;
            ViewBag.Areas = areaList;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            List<SelectListItem> staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();

            List<SelectListItem> areaList = (from s in await _areaService.GetAreasWithStaff()
                                             select new SelectListItem
                                             {
                                                 Text = s.Name,
                                                 Value = s.Id.ToString()
                                             }).ToList();
            ViewBag.Staffs = staffList;
            ViewBag.Areas = areaList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddDutyAssignViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _dutyAssignService.AddAsync(_mapper.Map<DutyAssign>(model));
                TempData["resultDutyAssign"] = "DutyAssign created successfully";
                return RedirectToAction(nameof(List));
            }

            List<SelectListItem> staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();

            List<SelectListItem> areaList = (from s in await _areaService.GetAreasWithStaff()
                                             select new SelectListItem
                                             {
                                                 Text = s.Name,
                                                 Value = s.Id.ToString()
                                             }).ToList();
            ViewBag.Staffs = staffList;
            ViewBag.Areas = areaList;

            return View(model);
        }

        public async Task<IActionResult> DutyAssignIsActive(int id)
        {
            var listDutyAssign = await _dutyAssignService.GetDutyAssignsWithStaffAndArea();
            var dutyAssign = listDutyAssign.Where(x => x.Id == id).FirstOrDefault();
            var name = dutyAssign.Staff.FullName;
            if (dutyAssign != null)
            {
                if (dutyAssign.IsActive)
                {
                    dutyAssign.IsActive = false;
                    TempData["resultDutyAssign"] = $"{name} is inactived";
                }
                else
                {
                    dutyAssign.IsActive = true;
                    TempData["resultDutyAssign"] = $"{name} is actived";
                }
                await _dutyAssignService.UpdateAsync(_mapper.Map<DutyAssign>(dutyAssign));
                return RedirectToAction(nameof(List));
            }
            return View(dutyAssign);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dutyAssign = await _dutyAssignService.GetByIdAsync(id);
            if (dutyAssign == null)
            {
                throw new NotFoundException($"{id} nolu dutyassign not found");
            }

            List<SelectListItem> staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();

            List<SelectListItem> areaList = (from s in await _areaService.GetAreasWithStaff()
                                             select new SelectListItem
                                             {
                                                 Text = s.Name,
                                                 Value = s.Id.ToString()
                                             }).ToList();
            ViewBag.Staffs = staffList;
            ViewBag.Areas = areaList;

            return View(_mapper.Map<EditDutyAssignViewModel>(dutyAssign));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDutyAssignViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _dutyAssignService.UpdateAsync(_mapper.Map<DutyAssign>(model));
                TempData["resultDutyAssign"] = "DutyAssign updated successfully";
                return RedirectToAction(nameof(List));
            }

            List<SelectListItem> staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();

            List<SelectListItem> areaList = (from s in await _areaService.GetAreasWithStaff()
                                             select new SelectListItem
                                             {
                                                 Text = s.Name,
                                                 Value = s.Id.ToString()
                                             }).ToList();
            ViewBag.Staffs = staffList;
            ViewBag.Areas = areaList;

            return View(model);
        }
        public async Task<IActionResult> Remove(int id)
        {
            var dutyAssign = await _dutyAssignService.GetByIdAsync(id);
            if (dutyAssign == null)
            {
                throw new NotFoundException($"({id}) nolu dutyassign not found");
            }

            await _dutyAssignService.RemoveAsync(dutyAssign);
            TempData["resultDutyAssign"] = "DutyAssign removed successfully";
            return RedirectToAction(nameof(List));
        }
    }
}
