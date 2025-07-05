using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{6,}$",
            ErrorMessage = "Пароль должен содержать 1 заглавную букву, 1 цифру и 1 спецсимвол")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
