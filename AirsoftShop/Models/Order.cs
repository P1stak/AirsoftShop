namespace AirsoftShop.Models
{
    public class Order
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Cart Carts { get; set; } // для хранения данных пользователей совершивших покупки в панели администратора
    }
}
