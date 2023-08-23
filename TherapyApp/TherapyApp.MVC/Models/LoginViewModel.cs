using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TherapyApp.MVC.Models
{
    public class LoginViewModel
    {
        [DisplayName("UserName")]
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("IsPersistent")]
        public bool IsPersistent { get; set; }
        //public string ReturnUrl { get; set; }
    }
}
