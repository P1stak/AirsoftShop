using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Data.Interfacees;

namespace AirsoftShop.Views.Shared.ViewComponents.CartViewComponents
{
    public class CalcFavoriteProductsCountViewComponent : ViewComponent
    {
        private readonly IFavoriteDbRepository _favoriteDbRepository;

        public CalcFavoriteProductsCountViewComponent(IFavoriteDbRepository favoriteDbRepository)
        {
            _favoriteDbRepository = favoriteDbRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productsCount = _favoriteDbRepository.GetAll(Constants.UserId).Count;
            return View("FavoriteProductsCountView", productsCount);
        }
    }
}
