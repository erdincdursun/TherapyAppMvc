using System.ComponentModel.DataAnnotations;

namespace TherapyApp.MVC.Areas.Admin.Models
{
    public class CategoryUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field must be left blank.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description field must be left blank.")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string Url { get; set; }
        

    }
}
