using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TherapyApp.Business.Abstract;
using TherapyApp.Entity.Concrete;
using TherapyApp.MVC.Models;

namespace TherapyApp.MVC.Controllers
{
    public class AdvisorController : Controller
    {
        private readonly IAdvisorService _advisorManager;

        public AdvisorController(IAdvisorService advisorManager)
        {
            _advisorManager = advisorManager;
        }

        public async Task<IActionResult> AdvisorList(string categoryurl = null, string brancherurl = null)
        {
            List<Advisor> advisorList = await _advisorManager.GetAllActiveAdvisorsAsync(categoryurl, brancherurl);
            return View(advisorList);
        }

        [HttpGet]
        public async Task<IActionResult> Question(int id)
        {
            var model = await _advisorManager.GetByIdAsync(id);
            return View(model);
        }
        public async Task<IActionResult> Appointment()
        {

            return View();
        }

    }
}
