using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class SignupRequest : LoginRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(8, ErrorMessage = "Min. password length is 8.")]
        [MaxLength(32, ErrorMessage = "Max. password length is 32")]
        public string ConfirmPassword { get; set; }
    }
}
