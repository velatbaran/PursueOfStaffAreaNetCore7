using Microsoft.AspNetCore.Mvc;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
