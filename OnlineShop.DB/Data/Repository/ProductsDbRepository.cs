using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Data.Interfacees;
using OnlineShop.DB.Models;

namespace OnlineShop.DB.Data.Repository
{
    public class ProductsDbRepository : IProductsDbRepository
    {
        private readonly DatabaseContext _dbContext;

        public ProductsDbRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
        public void Delete(Guid productId)
        {
            //var product = _dbContext.Products.FirstOrDefault(x => x.Id == productId);
            //_dbContext.Remove(product);
            //_dbContext.SaveChanges();

            var product = TryGetById(productId);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public Product TryGetById(Guid id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
        }
        public void Update(Product product)
        {
            var existingproduct = _dbContext.Products.FirstOrDefault(x => x.Id == product.Id);
            if (existingproduct == null)
            {
                return;
            }

            existingproduct.Name = product.Name;
            existingproduct.Description = product.Description;
            existingproduct.Cost = product.Cost;
            existingproduct.ImageUrl = product.ImageUrl;
            _dbContext.SaveChanges();
        }
    }
}
