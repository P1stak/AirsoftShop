using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItemViewModel> Items { get; set; }

        
        public OrderStatus Status { get; set; }
        public DateTime CreateDateTime { get; set; }


        public decimal TotalCost => Items?.Sum(x => x.Cost) ?? 0;
        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
        }   
    }
}
