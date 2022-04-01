using FreshShop.Data;
using FreshShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class AdminUserController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        FreshShopContext _db;
        public AdminUserController(UserManager<ApplicationUser> userManager, FreshShopContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [Route("UserList")]
        public IActionResult Index()
        {
            return View(_db.Users.ToList());
        }

        [Route("AddNewUser")]
        public async Task<IActionResult> AddNewUser()
        {
            return View();
        }

        [Route("AddNewUser")]
        [HttpPost]
        public async Task<IActionResult> AddNewUser(ApplicationUser user)
        {
            if(ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                    var isSaveRole = await _userManager.AddToRoleAsync(user,role:"User");
                    TempData["Save"] = "User has been created successfully";
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            
            return View();
        }

        [Route("EditUser")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = _db.Users.FirstOrDefault(c => c.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [Route("EditUser")]
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            var userInfo = _db.Users.FirstOrDefault(c => c.Id == user.Id);
            if(userInfo == null)
            {
                return NotFound();
            }
            userInfo.Name = user.Name;
            userInfo.Address = user.Address;
            userInfo.City = user.City;
            var result = await _userManager.UpdateAsync(userInfo);
            if(result.Succeeded)
            {
                TempData["save"] = "User has been updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("UserDetails")]
        public async Task<IActionResult> Details(string id)
        {
            var user = _db.Users.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [Route("LockoutUser")]
        public async Task<IActionResult> Lockout(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var user = _db.Users.FirstOrDefault(c => c.Id == id);
            if (user==null)
            {
                return NotFound();
            }
            return View(user);
        }

        [Route("LockoutUser")]
        [HttpPost]
        public async Task<IActionResult> Lockout(ApplicationUser user)
        {
            var userInfo = _db.Users.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo==null)
            {
                return NotFound();
            }
            userInfo.LockoutEnd = DateTime.Now.AddYears(100);
            int rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["save"] = "User has been lockout successfully";
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }

        [Route("ActiveUser")]
        public async Task<IActionResult> Active(string id)
        {
            var user = _db.Users.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [Route("ActiveUser")]
        [HttpPost]
        public async Task<IActionResult> Active(ApplicationUser user)
        {
            var userInfo = _db.Users.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.LockoutEnd = DateTime.Now.AddDays(-1);
            int rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["save"] = "User has been done active successfully";
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }

        [Route("DeleteUser")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = _db.Users.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [Route("DeleteUser")]
        [HttpPost]
        public async Task<IActionResult> Delete(ApplicationUser user)
        {
            var userInfo = _db.Users.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo == null)
            {
                return NotFound();
            }
            _db.Users.Remove(userInfo);
            int rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["save"] = "User has been deleted successfully";
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }
    }
}
