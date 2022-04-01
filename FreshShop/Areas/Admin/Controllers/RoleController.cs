using FreshShop.Areas.Admin.Models;
using FreshShop.Data;
using FreshShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;
        FreshShopContext _db;
        public RoleController(RoleManager<IdentityRole> roleManager, FreshShopContext db, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _db = db;
            _userManager = userManager;
        }

        [Route("RoleList")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View();
        }
        [Authorize]
        [Route("AddNewRole")]
        public async Task<IActionResult> AddNewRole()
        {
            return View();
        }

        [Route("AddNewRole")]
        [HttpPost]
        public async Task<IActionResult> AddNewRole(string name)
        {
            IdentityRole role = new IdentityRole();
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            if (isExist)
            {
                ViewBag.msg = "This role already exists";
                ViewBag.name = name;
                return View();
            }
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                TempData["save"] = "Role has been added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("EditRole")]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }

        [Route("EditRole")]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            if (isExist)
            {
                ViewBag.msg = "This role already exists";
                ViewBag.name = name;
                return View();
            }
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                TempData["save"] = "Role has been updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("DeleteRole")]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }


        [Route("DeleteRole")]
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["save"] = "Role has been deleted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("AssignRole")]
        public async Task<IActionResult> Assign()
        {
            ViewData["UserId"] = new SelectList(_db.Users.Where(f => f.LockoutEnd < DateTime.Now || f.LockoutEnd == null).ToList(), "Id", "UserName");
            ViewData["RoleId"] = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");

            return View();
        }

        [Route("AssignRole")]
        [HttpPost]
        public async Task<IActionResult> Assign(RoleUserVm roleUser)
        {
            var user = _db.Users.FirstOrDefault(c => c.Id == roleUser.UserId);
            var isCheckRoleAssign = await _userManager.IsInRoleAsync(user, roleUser.RoleId);
            if (isCheckRoleAssign)
            {
                ViewBag.msg = "This user is already assigned for this role";
                ViewData["UserId"] = new SelectList(_db.Users.Where(f => f.LockoutEnd < DateTime.Now || f.LockoutEnd == null).ToList(), "Id", "UserName");
                ViewData["RoleId"] = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
                return View();
            }
            var role = await _userManager.AddToRoleAsync(user, roleUser.RoleId);
            if (role.Succeeded)
            {
                TempData["save"] = "User Role assigned";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("AssignUserRole")]
        public ActionResult AssignUserRole()
        {
            var result = from ur in _db.UserRoles
                         join r in _db.Roles on ur.RoleId equals r.Id
                         join a in _db.Users on ur.UserId equals a.Id
                         select new UserRoleMapping()
                         {
                             UserId = ur.UserId,
                             RoleId = ur.RoleId,
                             UserName = a.UserName,
                             RoleName = r.Name
                         };
            ViewBag.UserRoles = result;
            return View();
        }
    }
}
