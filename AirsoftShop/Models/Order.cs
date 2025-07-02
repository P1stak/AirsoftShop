namespace AirsoftShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsRemember { get; set; } = false;
        public string Phone { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal Cost { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public Cart Carts { get; set; } // для хранения данных пользователей совершивших покупки в панели администратора
    }
}
