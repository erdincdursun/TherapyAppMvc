using Microsoft.AspNetCore.Mvc;
using TherapyApp.Business.Abstract;

namespace TherapyApp.MVC.Components
{
    public class CategoriesMenuViewComponent :ViewComponent
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesMenuViewComponent(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryManager.GetAllAsync();
            return View(categories);
        }
    }
}
