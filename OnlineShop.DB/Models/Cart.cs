namespace OnlineShop.DB.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        //public UserDeliveryInfo User { get; set; } = new UserDeliveryInfo();

        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}
