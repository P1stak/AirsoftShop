using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;

namespace AirsoftShop.Views.Shared.ViewComponents.CartViewComponents
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

            var cartViewModel = Mapping.ToCartViewModel(cart);

            var productCount = cartViewModel?.Amount ?? 0;

            return View("Cart", productCount);
        }
    }
}
