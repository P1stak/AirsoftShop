using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Data.Interfacees;

namespace AirsoftShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsDbRepository _productsDbRepository;

        public HomeController(IProductsDbRepository productsDbRepository)
        {
            _productsDbRepository = productsDbRepository;
        }

        public IActionResult Index()
        {
            var products = _productsDbRepository.GetAll();
            return View(products.ToProductViewModels());
        }
    }
}
