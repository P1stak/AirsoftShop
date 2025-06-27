using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AirsoftShop.Controllers
{
    public class HomeController : Controller
    {
        private ProductsRepository _productRepository;

        public HomeController()
        {
            _productRepository = new ProductsRepository();
        }

        public IActionResult Index()
        {

            var product = _productRepository.GetAll();
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
