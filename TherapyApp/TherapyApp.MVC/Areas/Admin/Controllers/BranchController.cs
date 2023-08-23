using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TherapyApp.Business.Abstract;
using TherapyApp.Business.Concrete;
using TherapyApp.Core;
using TherapyApp.Entity.Concrete;
using TherapyApp.MVC.Areas.Admin.Models;

namespace TherapyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchManager;
        private readonly INotyfService _notyf;

        public BranchController(IBranchService branchManager, INotyfService notyf)
        {
            _branchManager = branchManager;
            _notyf = notyf;
        }

        #region AllList
        public async Task<IActionResult> Index()
        {
            List<Branch> branchList = await _branchManager.GetAllBranchAsync(false);
            return View(branchList);
        }

        #endregion
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BranchAddViewModel branchAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Branch branch = new Branch
                {
                    Name = branchAddViewModel.Name,
                    Url = Jobs.GetUrl(branchAddViewModel.Name)
                };
                await _branchManager.CreateAsync(branch);
                _notyf.Success("Registration completed successfully");
                return RedirectToAction("Index");
            }
            return View(branchAddViewModel);
        }
        #endregion
        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _branchManager.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> Update(Branch branch)
        {
            Branch _branch = await _branchManager.GetByIdAsync(branch.Id);
            _branch.Name = branch.Name;
            branch.Url = Jobs.GetUrl(branch.Name) ;
            _branch.Url = branch.Url;
            _branch.IsActive = branch.IsActive;
            _branch.ModifiedDate = DateTime.Now;
            _branchManager.Update(_branch);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Branch branch = await _branchManager.GetByIdAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            branch.IsActive = !branch.IsActive;
            branch.ModifiedDate = DateTime.Now;
            _branchManager.Update(branch);
            return RedirectToAction("Index");
        }
        #endregion
        #region Delete
        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            Branch branch = await _branchManager.GetByIdAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            branch.IsDeleted = !branch.IsDeleted;
            branch.ModifiedDate = DateTime.Now;
            _branchManager.Update(branch);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            Branch branch = await _branchManager.GetByIdAsync(id);
            if (branch == null) return NotFound();
            _branchManager.Delete(branch);
            _notyf.Success("The record has been permanently deleted from the database.");
            return RedirectToAction("Index");
        }

        #endregion
      



    }

}
