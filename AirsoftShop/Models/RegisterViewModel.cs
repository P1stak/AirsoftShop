using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{6,}$",
        ErrorMessage = "Пароль должен содержать 1 заглавную букву, 1 цифру и 1 спецсимвол")]
        public string Password { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Phone(ErrorMessage = "Некорректный формат телефона")]
        [RegularExpression(
        @"^(\+7|7|8)?[\s\-]?\(?[0-9]{3}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$",
        ErrorMessage = "Некорректный формат телефона. Пример: +7(XXX)XXX-XX-XX или 8XXXXXXXXXX")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Поле обязательно")]
        public string UserName { get; set; }

        public string Address { get; set; }

        public string ReturnUrl { get; set; }

    }
}
