using AirsoftShop.Models;

namespace AirsoftShop
{
    public static class CartsRepository
    {
        /// <summary>
        /// список всех корзин пользователей
        /// </summary>
        private static List<Cart> carts = new List<Cart>();

        /// <summary>
        /// Метод находит конкретного пользователя из всех корзин
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(c => c.UserId == userId);
        }

        public static void Add(Product product, string userId)
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

                if (exictingCart != null)
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
