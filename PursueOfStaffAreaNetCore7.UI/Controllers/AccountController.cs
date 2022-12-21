using Microsoft.AspNetCore.Mvc;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Account;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

    }
}
