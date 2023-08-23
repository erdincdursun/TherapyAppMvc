using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TherapyApp.MVC.Models
{
    public class ForgotPasswordViewModel
    {
        public string UserId { get; set; }
        public string Toke { get;set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Password Repeat")]
        [Required(ErrorMessage = "Password should not be left blank again")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The two passwords must be the same.")]
        public string RePassword { get; set; }
    }
}
