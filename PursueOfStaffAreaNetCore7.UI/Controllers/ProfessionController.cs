using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Exceptions;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.AllowType;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Profession;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    public class ProfessionController : Controller
    {
        private readonly IService<Profession> _service;
        private readonly IMapper _mapper;

        public ProfessionController(IService<Profession> service, IMapper mapper)
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
        public async Task<IActionResult> Add(AddProfessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Profession>(model));
                TempData["result"] = "Profession created successfully";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Profession profession = await _service.GetByIdAsync(id);
            if (profession == null)
            {
                throw new NotFoundException($"({id}) nolu profession not found");
            }
            return View(_mapper.Map<EditProfessionViewModel>(profession));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProfessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Profession>(model));
                TempData["result"] = "Profession updated successfully";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            Profession profession = await _service.GetByIdAsync(id);
            if (profession == null)
            {
                throw new NotFoundException($"({id}) nolu profession not found");
            }

            await _service.RemoveAsync(profession);
            TempData["result"] = "Profession removed successfully";
            return RedirectToAction(nameof(List));
        }
    }
}
