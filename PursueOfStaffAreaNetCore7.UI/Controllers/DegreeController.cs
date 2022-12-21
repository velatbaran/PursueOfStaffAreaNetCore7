using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Exceptions;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Degree;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Department;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    [Authorize]
    public class DegreeController : Controller
    {
        private readonly IService<Degree> _service;
        private readonly IMapper _mapper;

        public DegreeController(IService<Degree> service, IMapper mapper)
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
        public async Task<IActionResult> Add(AddDegreeViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RegisteringUser = User.FindFirst("Username").Value;
                await _service.AddAsync(_mapper.Map<Degree>(model));
                TempData["resultDegree"] = "Degree created successfully";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Degree degree = await _service.GetByIdAsync(id);
            if (degree == null)
            {
                throw new NotFoundException($"({id}) nolu degree not found");
            }
            return View(_mapper.Map<EditDegreeViewModel>(degree));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDegreeViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RegisteringUser = User.FindFirst("Username").Value;
                await _service.UpdateAsync(_mapper.Map<Degree>(model));
                TempData["resultDegree"] = "Degree updated successfully";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            Degree degree = await _service.GetByIdAsync(id);
            if (degree == null)
            {
                throw new NotFoundException($"({id}) nolu degree not found");
            }

            await _service.RemoveAsync(degree);
            TempData["resultDegree"] = "Degree removed successfully";
            return RedirectToAction(nameof(List));
        }
    }
}
