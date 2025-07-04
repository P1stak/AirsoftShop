using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Некорректный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Минимум 6 символов")]
        [MaxLength(20, ErrorMessage = "Максимум 20 символов")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{6,}$",
            ErrorMessage = "Пароль должен содержать 1 заглавную букву, 1 цифру и 1 спецсимвол")]
        public string Password { get; set; }


        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
