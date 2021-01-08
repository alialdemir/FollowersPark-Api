using System.ComponentModel.DataAnnotations;

namespace FollowersPark.Models.User
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mail adresi zorunlu alan.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunlu alan.")]
        public string Password { get; set; }
    }
}