using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Areas.Admin.Contollers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductsRepository _productsRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = _productsRepository.GetAll();
            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productsRepository.Add(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int productId)
        {
            var product = _productsRepository.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productsRepository.Update(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int productId)
        {
            var product = _productsRepository.TryGetById(productId);
            if (product != null)
            {
                _productsRepository.GetAll().Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
