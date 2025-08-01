namespace OnlineShop.DB.Models
{
    public class FavoriteProduct
    {
        public Guid Id { get; set; }
        public string userId { get; set; }
        public Product Product { get; set; }
    }
}
