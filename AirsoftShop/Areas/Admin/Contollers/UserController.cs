using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Areas.Admin.Contollers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
