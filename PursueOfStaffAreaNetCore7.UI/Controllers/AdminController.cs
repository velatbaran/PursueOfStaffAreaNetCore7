using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Concrete;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Exceptions;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Admin;
using PursueOfStaffAreaNetCore7.UI.Helpers;
using System.Collections.Generic;

namespace PursueOfStaffAreaNetCore7.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHasher _hasher;

        public AdminController(IUserService userService, IMapper mapper, IConfiguration configuration, IHasher hasher, IStaffService staffService)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
            _hasher = hasher;
            _staffService = staffService;
        }

        public async Task<IActionResult> ListUser()
        {
            return View(await _userService.GetUsersWithStaff());
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            List<SelectListItem> staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();
            ViewBag.Staffs = staffList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.AnyAsync(x => x.Username == model.Username || x.Email == model.Email))
                {
                    if (await _userService.AnyAsync(x => x.Username == model.Username))
                    {
                        ModelState.AddModelError(model.Username, $"{model.Username} username recorded already");
                    }
                    if (await _userService.AnyAsync(x => x.Email == model.Email))
                    {
                        ModelState.AddModelError(model.Email, $"{model.Email} email recorded already");
                    }
                    List<SelectListItem> _staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                                       select new SelectListItem
                                                       {
                                                           Text = s.FullName + " " + s.TC,
                                                           Value = s.Id.ToString()
                                                       }).ToList();
                    ViewBag.Staffs = _staffList;
                    return View(model);
                }

                model.Password = _hasher.DoMD5HashedString(model.Password);
                model.RePassword = _hasher.DoMD5HashedString(model.Password);
                model.RegisteringUser = User.FindFirst("Username").Value;
                await _userService.AddAsync(_mapper.Map<User>(model));
                TempData["resultUser"] = "User created successfully";
                return RedirectToAction(nameof(ListUser));
            }
            List<SelectListItem> staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();
            ViewBag.Staffs = staffList;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            User user = await _userService.GetByIdAsync(id);
            //ViewData["username"] = user.Username;
            //ViewData["email"] = user.Email;
            //ViewData["role"] = user.Role;
            if (user == null)
            {
                throw new NotFoundException($"{id} nolu user not found");
            }
            List<SelectListItem> staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();
            ViewBag.Staffs = staffList;
            return View(_mapper.Map<EditUserViewModel>(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.AnyAsync(x => x.Username == model.Username && x.Id != model.Id))
                {
                    ModelState.AddModelError(model.Username, $"{model.Username} username recorded already");
                    List<SelectListItem> _staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                                       select new SelectListItem
                                                       {
                                                           Text = s.FullName + " " + s.TC,
                                                           Value = s.Id.ToString()
                                                       }).ToList();
                    ViewBag.Staffs = _staffList;
                    return View(model);
                }
                if (await _userService.AnyAsync(x => x.Email == model.Email && x.Id != model.Id))
                {
                    ModelState.AddModelError(model.Email, $"{model.Email} email recorded already");
                    List<SelectListItem> _staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                                       select new SelectListItem
                                                       {
                                                           Text = s.FullName + " " + s.TC,
                                                           Value = s.Id.ToString()
                                                       }).ToList();
                    ViewBag.Staffs = _staffList;
                    return View(model);
                }

                User user = await _userService.GetByIdAsync(model.Id);
                model.RegisteringUser = User.FindFirst("Username").Value;
                await _userService.UpdateAsync(_mapper.Map(model,user));
                TempData["resultUser"] = "User updated successfully";
                return RedirectToAction(nameof(ListUser));
            }
            List<SelectListItem> staffList = (from s in await _staffService.GetStaffsWithAllEntities()
                                              select new SelectListItem
                                              {
                                                  Text = s.FullName + " " + s.TC,
                                                  Value = s.Id.ToString()
                                              }).ToList();
            ViewBag.Staffs = staffList;
            return View(model);
        }

        public async Task<IActionResult> DoUserIsLocked(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user.IsLocked)
            {
                user.IsLocked = false;
                TempData["resultUser"] = $"{user.Username} is unlocked";
            }
            else
            {
                user.IsLocked = true;
                TempData["resultUser"] = $"{user.Username} is locked";
            }
            user.RegisteringUser = User.FindFirst("Username").Value;
            await _userService.UpdateAsync(_mapper.Map<User>(user));
            return RedirectToAction(nameof(ListUser));
        }

        public async Task<IActionResult> RemoveUser(int id)
        {
            User user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException($"{id} nolu user not found");
            }
            await _userService.RemoveAsync(user);
            TempData["resultUser"] = "User removed successfully";
            return RedirectToAction(nameof(ListUser));
        }
    }
}
