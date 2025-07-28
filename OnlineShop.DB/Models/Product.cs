namespace OnlineShop.DB.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Descriprion { get; set; }
        public string ImageUrl { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Product()
        {
            CartItems = new List<CartItem>();
        }
    }
}
