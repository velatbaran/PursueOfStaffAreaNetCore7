using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Account;
using PursueOfStaffAreaNetCore7.UI.Helpers;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Admin;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHasher _hasher;

        public AccountController(IUserService userService, IHasher hasher)
        {
            _userService = userService;
            _hasher = hasher;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = _hasher.DoMD5HashedString(model.Password);
                List<ListUserViewModel> listUser =await _userService.GetUsersWithStaff();
                var user = listUser.Where(x => x.Username.ToLower() == model.Username.ToLower() && x.Password == hashedPassword).FirstOrDefault();
                if (user != null)
                {
                    if (user.IsLocked)
                    {
                        ModelState.AddModelError(model.Username, "User is locked");
                        return View(model);
                    }
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.Staff.FullName ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    claims.Add(new Claim(ClaimTypes.Actor, user.Staff.Department.Name));
                    claims.Add(new Claim("Username", user.Username));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    TempData["resultUser"] = "Login is success";

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect.");
                }
            }
            return View(model);
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["result"] = "SignOut is success";
            return RedirectToAction(nameof(Login));
        }
    }
}
