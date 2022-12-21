using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Exceptions;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.AllowType;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    [Authorize]
    public class AllowTypeController : Controller
    {
        private readonly IService<AllowType> _service;
        private readonly IMapper _mapper;

        public AllowTypeController(IService<AllowType> service, IMapper mapper)
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
        public async Task<IActionResult> Add(AddAllowTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<AllowType>(model));
                TempData["resultAllowType"] = "AllowType created successfully";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AllowType allowModel = await _service.GetByIdAsync(id);
            if (allowModel == null)
            {
                throw new NotFoundException($"({id}) nolu allowtype not found");
            }
            return View(_mapper.Map<EditAllowTypeViewModel>(allowModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAllowTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<AllowType>(model));
                TempData["resultAllowType"] = "AllowType updated successfully";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            AllowType allowModel = await _service.GetByIdAsync(id);
            if (allowModel == null)
            {
                throw new NotFoundException($"({id}) nolu allowtype not found");
            }

            await _service.RemoveAsync(allowModel);
            TempData["resultAllowType"] = "AllowType removed successfully";
            return RedirectToAction(nameof(List));
        }
    }
}
