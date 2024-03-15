using System.ComponentModel.DataAnnotations;

namespace Core_Portfolio.Models
{
    public class AdminLoginViewModel
    {
        [Required(ErrorMessage = "Please enter your username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }
    }
}
