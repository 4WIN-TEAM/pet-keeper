using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetKeeper.Models;

namespace PetKeeper.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Roles()
        {
            if (ModelState.IsValid)
            {
                var result = new List<RoleViewModel>();
                result = _roleManager.Roles.Select(m => new RoleViewModel
                {
                    RoleId = m.Id,
                    RoleName = m.Name
                }).ToList();

                return View(result);
            }
            return View("Error404");
        }

        public ActionResult Create()
        {
            if (ModelState.IsValid)
            {
                return View("CreateRole");
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole { Name = model.RoleName });
                //_roleService.AddRoles(model);
                if (result.Succeeded)
                {
                    return Json(result);
                }
            }
            return Unauthorized();
        }

        public async Task<ActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View("EditRole", new RoleViewModel { RoleId = role.Id, RoleName = role.Name });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var findRole = await _roleManager.FindByIdAsync(model.RoleId);
                findRole.Name = model.RoleName;
                var roles = await _roleManager.UpdateAsync(findRole);
                if (roles.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                return RedirectToAction("Roles");
            }
            return Unauthorized();
        }

        public async Task<ActionResult> Details(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View("RoleDetails", new RoleViewModel { RoleId = role.Id, RoleName = role.Name });
        }

        public async Task<ActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View("DeleteRole", new RoleViewModel { RoleId = role.Id, RoleName = role.Name });
        }

        [HttpPost]
        public async Task<ActionResult> DeleteRole(RoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var result = await _roleManager.DeleteAsync(role);
            if (ModelState.IsValid)
            {
                if (result.Succeeded)
                {
                    return Json(result);
                }
            }
            return Unauthorized();
        }

        public async Task<ActionResult> Users()
        {
            var allUsers = _userManager.Users.ToList();
            var allUserAndRoles = new List<UserViewModel>();

            foreach (var user in allUsers)
            {
                var model = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = string.Join(", ", await _userManager.GetRolesAsync(user))
                };
                allUserAndRoles.Add(model);
            }
            return View(allUserAndRoles);
        }

        [HttpGet]
        public async Task<ActionResult> AddRole(string id)
        {
            var users = await _userManager.FindByIdAsync(id);

            var model = new UserViewModel
            {
                Roles = new SelectList(_roleManager.Roles.OrderBy(m => m.Name)),
                Id = id,
                UserName = users.UserName,
                Email = users.Email,
                Role = string.Join(", ", await _userManager.GetRolesAsync(users))
            };
            return View("AddUserRole", model);


        }

        [HttpPost]
        public async Task<ActionResult> AddRole(UserViewModel model)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                //user.Email = model.Email;
                //user.UserName = model.UserName;
                var roles = await _userManager.GetRolesAsync(user);

                if (User.IsInRole("Admin"))
                {
                    foreach (var role in roles)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role);
                    }
                }
                var result = await _userManager.AddToRoleAsync(user, model.Role);
                await _signInManager.RefreshSignInAsync(currentUser);
                if (result.Succeeded)
                {
                    return Json(result);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}