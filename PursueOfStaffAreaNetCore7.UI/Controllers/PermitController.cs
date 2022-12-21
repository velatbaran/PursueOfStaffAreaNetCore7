using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Concrete;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Permit;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    [Authorize]
    public class PermitController : Controller
    {
        private readonly StaffService _staffService;
        private readonly IMapper _mapper;

        public PermitController(StaffService staffService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddPermitViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
