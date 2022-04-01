using FreshShop.Areas.Admin.Models;
using FreshShop.Data;
using FreshShop.Models;
using FreshShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DashboardController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private FreshShopContext _db;
        RoleManager<IdentityRole> _roleManager;


        public DashboardController(RoleManager<IdentityRole> roleManager,IAccountRepository accountRepository, FreshShopContext db, UserManager<ApplicationUser> userManager)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;
        }
        [Route("Dashboard")]
        [Authorize]
        public IActionResult Dashboard()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            dashboard.products_count = _db.Products.Count();
            dashboard.users_count = _db.Users.Count();
            dashboard.category_count = _db.Category.Count();
            return View(dashboard);
        }

        [Route("loginadmin")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("loginadmin")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    var userInfo = _db.Users.FirstOrDefault(c => c.UserName.ToLower() == signInModel.Email.ToLower());
                    var roleInfo = (from ur in _db.UserRoles
                                    join r in _db.Roles on ur.RoleId equals r.Id
                                    where ur.UserId == userInfo.Id
                                    select new SessionUserVm()
                                    {
                                        UserName = signInModel.Email,
                                        RoleName = r.Name
                                    }).FirstOrDefault();
                    if (roleInfo != null)
                    {
                        HttpContext.Session.SetString(key: "roleName", value: roleInfo.RoleName);
                    }
                    return RedirectToAction("Dashboard");
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Not allowed to login");
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Account blocked! Please try after sometime.");
                }
                else
                {
                    ModelState.AddModelError("", "Invaild credentials");
                }
            }
            return View(signInModel);
        }

        [Route("logoutadmin")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Dashboard");
        }

        [Route("AdminProfile")]
        public IActionResult AdminProfile()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            if (userid == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ApplicationUser user = _userManager.FindByIdAsync(userid).Result;
                return View(user);
            }
        }

        [Route("EditAdminProfile")]
        public IActionResult EditAdminProfile()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            if (userid == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ApplicationUser user = _userManager.FindByIdAsync(userid).Result;
                return View(user);
            }
        }

        [Route("EditAdminProfile")]
        [HttpPost]
        public async Task<IActionResult> EditAdminProfile(ApplicationUser userdetails)
        {
            IdentityResult x = await _userManager.UpdateAsync(userdetails);
            if (x.Succeeded)
            {
                return RedirectToAction("Dashboard");
            }
            return View(userdetails);
        }
    }
}
