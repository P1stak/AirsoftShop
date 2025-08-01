namespace OnlineShop.DB.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Product()
        {
            CartItems = new List<CartItem>();
        }
        public Product(string name, decimal cost, string description, string ImageiUrl)
        {
            Name = name;
            Cost = cost;
            Description = description;
            ImageUrl = ImageiUrl;
        }
    }
}
