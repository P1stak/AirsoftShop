using AirsoftShop.Data.Interfaces;
using AirsoftShop.Data.Repositories;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
