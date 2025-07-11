﻿namespace AirsoftShop.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public UserDeliveryInfo User { get; set; } = new UserDeliveryInfo();
        public decimal Cost => Items?.Sum(x => x.Cost) ?? 0;
        public decimal Amount => Items?.Sum(x => x.Amount) ?? 0;
    }
}
