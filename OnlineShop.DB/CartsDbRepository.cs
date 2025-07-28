using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;

namespace OnlineShop.DB
{
    public class CartsDbRepository : ICartsDbRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return _databaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(c => c.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var exictingCart = TryGetByUserId(userId);

            // если корзина у пользователя null, создаём новую
            if (exictingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId
                };

                newCart.Items = new List<CartItem>()
                {
                    new CartItem
                    {
                        Amount = 1,
                        Product = product,
                        Cart = newCart
                    }
                };
                _databaseContext.Carts.Add(newCart);
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
                        Amount = 1,
                        Product = product,
                        Cart = exictingCart
                    });
                }
            }
            _databaseContext.SaveChanges();
        }

        public void DecreaseAmount(Guid productId, string userId)
        {
            // получаем существующую позицию в корзине
            var exictingCart = TryGetByUserId(userId);

            // находим и проверяем ее везде на null
            var existingCartItem = exictingCart?.Items?.FirstOrDefault(x => x.Product.Id == productId);

            // если null то оставляем как есть
            if (existingCartItem == null)
            {
                return;
            }
            existingCartItem.Amount -= 1;

            // если позиции нет, то очищаем эту позицию с корзины
            if (existingCartItem.Amount == 0)
            {
                exictingCart.Items.Remove(existingCartItem);
            }
            _databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var exictingCart = TryGetByUserId(userId);
            _databaseContext.Carts.Remove(exictingCart);
            _databaseContext.SaveChanges();
        }

    }
}