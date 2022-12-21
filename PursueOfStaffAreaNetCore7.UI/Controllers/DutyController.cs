using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Exceptions;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.AllowType;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Duty;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Profession;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    [Authorize]
    public class DutyController : Controller
    {
        private readonly IService<Duty> _service;
        private readonly IMapper _mapper;

        public DutyController(IService<Duty> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {
            return View(await _service.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddDutyViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Duty>(model));
                TempData["resultDuty"] = "Duty created successfully";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Duty duty = await _service.GetByIdAsync(id);
            if (duty == null)
            {
                throw new NotFoundException($"({id}) nolu duty not found");
            }
            return View(_mapper.Map<EditDutyViewModel>(duty));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDutyViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Duty>(model));
                TempData["resultDuty"] = "Duty updated successfully";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            Duty duty = await _service.GetByIdAsync(id);
            if (duty == null)
            {
                throw new NotFoundException($"({id}) nolu duty not found");
            }

            await _service.RemoveAsync(duty);
            TempData["resultDuty"] = "Duty removed successfully";
            return RedirectToAction(nameof(List));
        }
    }
}
