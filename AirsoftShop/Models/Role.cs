using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
