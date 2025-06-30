using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;

namespace AirsoftShop.Data.Repositories
{
    public class CartsInMemoryRepository : ICartsRepository
    {

        private List<Cart> carts = new List<Cart>();

        public Cart? TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(c => c.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var exictingCart = TryGetByUserId(userId);

            // если корзина у пользователя null, создаём новую
            if (exictingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>()
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }
                    }
                };
                carts.Add(newCart);
            }
            else
            {
                // есть ли такая же позиция в нашей корзине, которую пользователь хочет снова добавить
                var existingCartItem = exictingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);

                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    exictingCart.Items.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product
                    });
                }
            }
        }
    }
}
