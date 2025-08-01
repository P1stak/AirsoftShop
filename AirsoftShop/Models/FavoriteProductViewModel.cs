using OnlineShop.DB.Models;

namespace AirsoftShop.Models
{
    public class FavoriteProductViewModel
    {
        public Guid Id { get; set; }
        public string userId { get; set; }
        public Product Product { get; set; }


    }
}
