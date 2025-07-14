using AirsoftShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private ICartsRepository _cartsRepository;
        public CartViewComponent(ICartsRepository cartsRepository)
        {
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
