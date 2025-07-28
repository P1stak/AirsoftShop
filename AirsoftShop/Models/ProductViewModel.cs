using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public string Descriprion { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
