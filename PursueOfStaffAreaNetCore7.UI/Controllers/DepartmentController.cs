using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Exceptions;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.AllowType;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Department;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IService<Department> _service;
        private readonly IMapper _mapper;

        public DepartmentController(IService<Department> service, IMapper mapper)
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
        public async Task<IActionResult> Add(AddDepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RegisteringUser = User.FindFirst("Username").Value;
                await _service.AddAsync(_mapper.Map<Department>(model));
                TempData["resultDepartment"] = "Department created successfully";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Department department = await _service.GetByIdAsync(id);
            if (department == null)
            {
                throw new NotFoundException($"({id}) nolu department not found");
            }
            return View(_mapper.Map<EditDepartmentViewModel>(department));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RegisteringUser = User.FindFirst("Username").Value;
                await _service.UpdateAsync(_mapper.Map<Department>(model));
                TempData["resultDepartment"] = "Department updated successfully";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            Department department = await _service.GetByIdAsync(id);
            if (department == null)
            {
                throw new NotFoundException($"({id}) nolu department not found");
            }

            await _service.RemoveAsync(department);
            TempData["resultDepartment"] = "Department removed successfully";
            return RedirectToAction(nameof(List));
        }
    }
}
