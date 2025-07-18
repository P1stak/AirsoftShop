using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Models
{
    public class UserAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [RegularExpression(@"^[А-ЯЁ][а-яё]+\s[А-ЯЁ][а-яё]+\s[А-ЯЁ][а-яё]+$",
        ErrorMessage = "ФИО должно быть в формате 'Фамилия Имя Отчество' (кириллица, каждое слово с заглавной буквы)")]
        public string UserFullName { get; set; }

        public string Phone { get; set; }
    }
}
