using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Data.Interfacees;

namespace AirsoftShop.Views.Shared.ViewComponents.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private ICartsDbRepository _cartsDbRepository;
        public CartViewComponent(ICartsDbRepository cartsDbRepository)
        {
            _cartsDbRepository = cartsDbRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartsDbRepository.TryGetByUserId(Constants.UserId);

            var cartViewModel = cart.ToCartViewModel();

            var productCount = cartViewModel?.Amount ?? 0;

            return View("Cart", productCount);
        }
    }
}
