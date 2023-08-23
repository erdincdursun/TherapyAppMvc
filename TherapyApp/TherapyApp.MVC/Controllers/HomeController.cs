using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TherapyApp.Business.Abstract;
using TherapyApp.Core;
using TherapyApp.Entity.Concrete;
using TherapyApp.MVC.Areas.Admin.Models;
using TherapyApp.MVC.Models;

namespace TherapyApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvisorService _advisorManager;
        private readonly IBranchService _brancManager;
        private readonly ICategoryService _categoryManager;
        private readonly INotyfService _notyf;

        public HomeController(IAdvisorService advisorManager, IBranchService brancManager, ICategoryService categoryManager, INotyfService notyf)
        {
            _advisorManager = advisorManager;
            _brancManager = brancManager;
            _categoryManager = categoryManager;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            List<Advisor> model = await _advisorManager.GetAllAdvisorBranchAsync();
            return View(model);
        }

        public  IActionResult Contact()
        {
         
            return View();
        }

        public async Task<IActionResult> Review(int id)
        {
            var model = await _advisorManager.GetByIdAsync(id);
            return View(model);
        }
        #region NonAction
        [NonAction]
        private async Task<List<SelectListItem>> GetBranchSelectList()
        {
            List<Branch> branchList = await _brancManager.GetAllBranchAsync(false);
            List<SelectListItem> branchViewModelList = branchList.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            }).ToList();
            return branchViewModelList;
        }
        [NonAction]
        private async Task<List<SelectListItem>> GetCategorySelectList()
        {
            List<Category> categoryList = await _categoryManager.GetAllCategoryAsync(false);
            List<SelectListItem> categoryViewModelList = categoryList.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return categoryViewModelList;
        }





        #endregion

        [HttpGet]
        public async Task<IActionResult> NewAdvisor()
        {
            var branchList = await GetBranchSelectList();
            var categoryList = await GetCategorySelectList();
            AdvisorAddViewModel advisorAddViewModel = new AdvisorAddViewModel
            {
                BranchList = branchList,
                CategoryList = categoryList
            };
            return View(advisorAddViewModel);
        }
        [HttpPost]
        public  IActionResult NewAdvisor(AdvisorAddViewModel advisorAddViewModel)
        {
            if (ModelState.IsValid)
            {
                string name = advisorAddViewModel.FirstName + " " + advisorAddViewModel.LastName;
                Advisor advisor = new Advisor
                {
                    FirstName = advisorAddViewModel.FirstName,
                    LastName = advisorAddViewModel.LastName,
                    About = advisorAddViewModel.About,
                    IsActive = advisorAddViewModel.IsActive,
                    BranchId = advisorAddViewModel.BranchId,
                    Url = Jobs.GetUrl(name),
                    PhotoUrl = "default.jpg"

                };
                _advisorManager.CreateAsync(advisor);
                _notyf.Success("Your advisor request has been received successfully.");
                return RedirectToAction("Index");
            }
            return View(advisorAddViewModel);
        }
        }

    }
