using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TherapyApp.Business.Abstract;
using TherapyApp.Business.Concrete;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdvisorController : Controller
    {
        private readonly IAdvisorService _advisorManager;

        public AdvisorController(IAdvisorService advisorManager)
        {
            _advisorManager = advisorManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Advisor> advisorList = await _advisorManager.GetAllAsync();
            return View(advisorList);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Advisor advisor = await _advisorManager.GetByIdAsync(id);
            if (advisor == null)
            {
                return NotFound();
            }
            advisor.IsActive = !advisor.IsActive;
            advisor.ModifiedDate = DateTime.Now;
            _advisorManager.Update(advisor);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
