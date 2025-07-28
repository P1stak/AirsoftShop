using AirsoftShop.Helpers;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;

namespace AirsoftShop.Areas.Admin.Contollers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductsDbRepository _productsDbRepository;

        public ProductController(IProductsDbRepository productsDbRepository)
        {
            _productsDbRepository = productsDbRepository;
        }

        public IActionResult Index()
        {
            var products = _productsDbRepository.GetAll();
            return View(Mapping.ToProductViewModels(products));
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDB = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Descriprion = product.Descriprion,
                ImageUrl = product.ImageUrl
            };

            _productsDbRepository.Add(productDB);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Guid productId)
        {
            var product = _productsDbRepository.TryGetById(productId);

            var res = Mapping.ToProductViewModel(product);

            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDB = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Descriprion = product.Descriprion,
                ImageUrl = product.ImageUrl
            };

            _productsDbRepository.Update(productDB);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid productId)
        {
            var product = _productsDbRepository.TryGetById(productId);
            if (product != null)
            {
                _productsDbRepository.GetAll().Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
