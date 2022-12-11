using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Area;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
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

        private async Task DropDpwnListStaffLoader()
        {
            List<SelectListItem> staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();
            ViewBag.Staffs = staffList;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            DropDpwnListStaffLoader();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _areaService.AddAsync(_mapper.Map<Area>(model));
                TempData["resultArea"] = "Area created successfully";
                return RedirectToAction(nameof(List));
            }
            DropDpwnListStaffLoader();
            return View(model);
        }
    }
}
