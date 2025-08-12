using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле заполните это поле")]
        [EmailAddress(ErrorMessage = "Введите действительный адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле заполните это поле")]
        [StringLength(25, MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{6,}$",
            ErrorMessage = "Пароль должен содержать 1 заглавную букву, 1 цифру и 1 спецсимвол")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
