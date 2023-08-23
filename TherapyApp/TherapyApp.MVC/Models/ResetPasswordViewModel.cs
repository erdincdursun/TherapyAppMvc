using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TherapyApp.MVC.Models
{
    public class ResetPasswordViewModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password should not be left blank again")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Password Repeat")]
        [Required(ErrorMessage = "Password should not be left blank again")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Passwords did not match.")]
        public string RePassword { get; set; }
    }
}
