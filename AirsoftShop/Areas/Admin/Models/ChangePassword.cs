using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Areas.Admin.Models
{
    public class ChangePassword
    {
        public string UserName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{6,}$",
        ErrorMessage = "Пароль должен содержать 1 заглавную букву, 1 цифру и 1 спецсимвол")]
        public string Password { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
