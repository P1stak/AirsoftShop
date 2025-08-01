using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Data.Interfacees;
using OnlineShop.DB.Models;

namespace OnlineShop.DB.Data.Repository
{
    public class FavoriteDbRepository : IFavoriteDbRepository
    {
        private readonly DatabaseContext _dbContext;

        public FavoriteDbRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(string userId, Product product)
        {
            var existingCart = _dbContext.FavoriteProducts.FirstOrDefault(x => x.userId == userId && x.Product.Id == product.Id);
            if (existingCart == null)
            {
                _dbContext.FavoriteProducts.Add(new FavoriteProduct
                {
                    Product = product,
                    userId = userId
                });
                _dbContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var userVaforiteProducts = _dbContext.FavoriteProducts.Where(x => x.userId == userId).ToList();
            _dbContext.FavoriteProducts.RemoveRange(userVaforiteProducts);
            _dbContext.SaveChanges();
        }

        public List<Product> GetAll(string userId)
        {
            return _dbContext.FavoriteProducts.Where(x => x.userId == userId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();
        }

        public void Remove(string userId, Guid productId)
        {
            var existingFavorite = _dbContext.FavoriteProducts.FirstOrDefault(x => x.userId == userId && x.Product.Id == productId);
            _dbContext.FavoriteProducts.Remove(existingFavorite);
            _dbContext.SaveChanges();
        }

    }
}
