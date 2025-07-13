using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Areas.Admin.Contollers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private IOrdersRepository _ordersRepository;
        private ILogger<IOrdersRepository> _logger;

        public OrderController(IOrdersRepository ordersRepository, ILogger<IOrdersRepository> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var order = _ordersRepository.GetAll();
            return View(order);
        }
        public IActionResult Detail(Guid orderId)
        {
            var order = _ordersRepository.TryGetById(orderId);
            return View(order);
        }
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            _ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));

        }
    }
}
