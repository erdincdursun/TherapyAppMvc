using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TherapyApp.Business.Abstract;
using TherapyApp.Business.Concrete;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly INotyfService _notyf;

        public HomeController(UserManager<User> userManager, RoleManager<Role> roleManager, INotyfService notyf)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region User
        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        #endregion
        #region Role
        public async Task<IActionResult> RoleList()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        
        #endregion
    }
}
