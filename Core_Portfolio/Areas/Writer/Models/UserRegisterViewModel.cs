using System.ComponentModel.DataAnnotations;

namespace Core_Portfolio.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your surname!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your image url!")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage ="Please enter your username!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter password again!")]
        [Compare("Password",ErrorMessage = "Passwords entered are not the same")]
        public string ConfirmPassword { get; set; }

        public string Mail { get; set; }
    }
}
