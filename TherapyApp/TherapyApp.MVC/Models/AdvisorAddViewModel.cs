using Microsoft.AspNetCore.Mvc.Rendering;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.MVC.Models
{
    public class AdvisorAddViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public decimal Price { get; set; }
        public string Education { get; set; }
        public string About { get; set; }
        public bool IsActive { get; set; } = false;
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> BranchList { get; set; }
        public int CategoryId { get; set; }
        public int BranchId { get; set; }

    }
}
