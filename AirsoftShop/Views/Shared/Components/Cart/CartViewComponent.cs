using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private IProductsRepository _productRepository;
        private ICartsRepository _cartsRepository;
        public CartViewComponent(IProductsRepository productRepository, ICartsRepository cartsRepository)
        {
            _productRepository = productRepository;
            _cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            var productCounts = cart?.Amount ?? 0;

            return View("Cart", productCounts);
        }
    }
}
