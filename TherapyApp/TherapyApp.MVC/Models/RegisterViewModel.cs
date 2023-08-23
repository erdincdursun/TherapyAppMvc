using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TherapyApp.MVC.Models
{
    public class RegisterViewModel
    {

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Name Field should not be blank")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name Field should not be blank")]
        public string LastName { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = " User Name Field should not be blank")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email Field should not be blank")]
        [DataType(DataType.EmailAddress, ErrorMessage = "A valid e-mail address must be entered.")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password should not be left blank.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Password Repeat")]
        [Required(ErrorMessage = "Password should not be left blank again")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The two passwords must be the same.")]
        public string RePassword { get; set; }
    }
}
