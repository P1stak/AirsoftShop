using AirsoftShop.Helpers;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Data.Interfacees;
using OnlineShop.DB.Models;

namespace AirsoftShop.Areas.Admin.Contollers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsDbRepository _productsDbRepository;

        public ProductController(IProductsDbRepository productsDbRepository)
        {
            _productsDbRepository = productsDbRepository;
        }

        public IActionResult Index()
        {
            var products = _productsDbRepository.GetAll();
            return View(products.ToProductViewModels());
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

            _productsDbRepository.Add(product.ToProduct());
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Guid productId)
        {
            var product = _productsDbRepository.TryGetById(productId);
            return View(product.ToProductViewModel());
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _productsDbRepository.Update(product.ToProduct());
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
