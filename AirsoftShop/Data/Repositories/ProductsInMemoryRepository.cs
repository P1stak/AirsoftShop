using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;

namespace AirsoftShop.Data.Repositories
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product("АКС-74", 23500, "Автомат страйкбольный E&L АКС-74 ELS-74 MN Gen2", "/images/ak74.jpg"),
            new Product("CM.518", 10000, "Страйкбольная штурмовая винтовка Cyma CM.518", "/images/cyma518.jpg"),
            new Product("Colt 1911", 2500, "Пистолет страйкбольный Colt 1911 STTI Green Gas", "/images/1911.jpg"),
            new Product("MP7", 5000, "Пистолет-пулемет страйкбольный MP7 R4 WELL Plastic Body", "/images/mp7.jpg"),
            new Product("РПК-74М", 22000, "Пулемет страйкбольный РПК-74М CYMA CM.052А", "/images/rpk-74m.jpg"),
            new Product("Mauser C96", 4000, "Пистолет страйкбольный WELL Mauser C96 CO2", "/images/c96.jpg"),
            new Product("G36-C", 9000, "Автомат страйкбольный G36-C Specna Arms SA-G12 EBB Tan", "/images/G36-C.jpg"),
            new Product("M56DL", 4500, "Дробовик EE M56DL Black", "/images/M56DL.jpg"),
            new Product("ГП-1", 12000 ,"Подствольный гранатомет Pyrosoft ГП-1 ЗНИЧ", "/images/GP1.jpg"),
            new Product("Fenix AER-03", 1200, "Выносная тактическая кнопка Fenix AER-03 v2.0", "/images/aer.jpg"),
            new Product("Г52Д", 4500 , "Гильза Г52Д для гранатомёта страйкбольного Pyrosof", "/images/G52D.jpg"),
        };

        public void Add(Product product)
        {
            products.Add(product);
        }
        public void Delete(int productId)
        {
            var res = products.FirstOrDefault(x => x.Id == productId);
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product? TryGetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
        public void Update(Product product)
        {
            var existingproduct = products.FirstOrDefault(x => x.Id == product.Id);
            if (existingproduct == null)
            {
                return;
            }

            existingproduct.Name = product.Name;
            existingproduct.Descriprion = product.Descriprion;
            existingproduct.Cost = product.Cost;
            existingproduct.ImageUrl = product.ImageUrl;
        }
    }
}
