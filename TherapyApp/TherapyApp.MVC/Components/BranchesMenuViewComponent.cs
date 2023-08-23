using Microsoft.AspNetCore.Mvc;
using TherapyApp.Business.Abstract;

namespace TherapyApp.MVC.Components
{
    public class BranchesMenuViewComponent :ViewComponent
    {
        private readonly IBranchService _branchManager;

        public BranchesMenuViewComponent(IBranchService branchManager)
        {
            _branchManager = branchManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var branches = await _branchManager.GetAllAsync();
            return View(branches);
        }
    }
}
