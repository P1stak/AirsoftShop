using AirsoftShop.Data.Interfaces;
using AirsoftShop.Helpers;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;

namespace AirsoftShop.OnlineShop.DB.Models;

[Area(Constants.AdminRoleName)]
[Authorize(Roles = Constants.AdminRoleName)]

public class OrderController : Controller
{
    private readonly IOrdersDbRepository _ordersRepository;
    private readonly ILogger<IOrdersDbRepository> _logger;

    public OrderController(IOrdersDbRepository ordersRepository, ILogger<IOrdersDbRepository> logger)
    {
        _ordersRepository = ordersRepository;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var order = _ordersRepository.GetAll();
        return View(order.Select(x => x.ToOrderViewModel()).ToList());
    }
    public IActionResult Detail(Guid orderId)
    {
        var order = _ordersRepository.TryGetById(orderId);
        return View(order.ToOrderViewModel());
    }
    public IActionResult UpdateOrderStatus(Guid orderId, OrderStatusViewModel status)
    {
        _ordersRepository.UpdateStatus(orderId, (OrderStatus)(int)status);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult RemoveOrder(Guid orderId)
    {
        var order = _ordersRepository.TryGetById(orderId);
        _ordersRepository.Remove(order.Id);
        return RedirectToAction(nameof(Index));
    }
}
