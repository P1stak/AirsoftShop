using AirsoftShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class HomeController : Controller
    {
        private IProductsRepository _productRepository;


        public HomeController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var product = _productRepository.GetAll();
            return View(product);
        }
    }
}
