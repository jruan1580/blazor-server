using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class LoginRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(8, ErrorMessage = "Min. password length is 8.")]
        [MaxLength(32, ErrorMessage = "Max. password length is 32")]
        public string Password { get; set; }
    }
}
