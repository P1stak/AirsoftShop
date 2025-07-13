using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Areas.Admin.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
