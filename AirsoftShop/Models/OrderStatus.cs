using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Заказ создан")]
        Created,

        [Display(Name = "Собираем заказ")]
        Processed,

        [Display(Name = "Заказ передан в доставку")]
        Delivering,

        [Display(Name = "Заказ доставлен")]
        Delivered,

        [Display(Name = "Заказ отменен")]
        Canceled
    }
}