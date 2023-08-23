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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryManager;
        private readonly INotyfService _notyf;

        public CategoryController(ICategoryService categoryManager, INotyfService notyf)
        {
            _categoryManager = categoryManager;
            _notyf = notyf;
        }

        #region All List
        public async Task<IActionResult> Index()
        {
            List<Category> categoryList = await _categoryManager.GetAllCategoryAsync(false);

            return View(categoryList);
        }
        #endregion
        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddViewModel categoryAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    Name = categoryAddViewModel.Name,
                    Description = categoryAddViewModel.Description,
                    IsActive = categoryAddViewModel.IsActive,
                    Url = Jobs.GetUrl(categoryAddViewModel.Name)

                };
                await _categoryManager.CreateAsync(category);
                _notyf.Success("Registration completed successfully");
                return RedirectToAction("Index");
            }

            return View(categoryAddViewModel);
        }



        #endregion
        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            CategoryUpdateViewModel categoryEditViewModel = new CategoryUpdateViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive
            };
            return View(categoryEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateViewModel categoryUpdateView)
        {
            if (ModelState.IsValid)
            {
                Category category = await _categoryManager.GetByIdAsync(categoryUpdateView.Id);
                category.Name = categoryUpdateView.Name;
                category.Description = categoryUpdateView.Description;
                category.IsActive = categoryUpdateView.IsActive;
                category.ModifiedDate = DateTime.Now;
                categoryUpdateView.Url = Jobs.GetUrl(categoryUpdateView.Name);
                category.Url = categoryUpdateView.Url;
                _categoryManager.Update(category);
                _notyf.Success("Update is Success");
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsActive = !category.IsActive;
            category.ModifiedDate = DateTime.Now;
            _categoryManager.Update(category);
            return RedirectToAction("Index");
        }
        #endregion
        #region Delete

        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null) return NotFound();
            _categoryManager.Delete(category);
            _notyf.Success("The record has been permanently deleted from the database.");
            return RedirectToAction("Index");
        }

        #endregion
        #region SoftDelete
        public async Task<IActionResult> SoftDelete(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsDeleted = !category.IsDeleted;
            category.ModifiedDate = DateTime.Now;
            _categoryManager.Update(category);
            return RedirectToAction("Index");
            //return category.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }

        #endregion



    }
}
