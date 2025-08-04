using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Areas.Admin.Models
{
    public class EditUserViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "ФИО должно содержать от 5 до 100 символов")]
        public string Name { get; set; }

        [Required]
        [Phone(ErrorMessage = "Некорректный формат телефона")]
        [RegularExpression(
        @"^(\+7|7|8)?[\s\-]?\(?[0-9]{3}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$",
        ErrorMessage = "Некорректный формат телефона. Пример: +7(XXX)XXX-XX-XX или 8XXXXXXXXXX")]
        public string Phone { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Адрес должен содержать от 10 до 200 символов")]
        public string Address { get; set; }
    }
}
