using Microsoft.AspNetCore.Mvc;
using SmartInventory.Application.Dto.Order;
using SmartInventory.Application.Service.Interface;


namespace SmartInventory.WebApi.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService OrderService)
        {
            _orderService = OrderService;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _orderService.GetAllOrderAsync();
            return View(res);
        }
        public async Task<IActionResult> Details(int id)
        {
            var res = await _orderService.GetOrderByIdAsync(id);
            return View(res);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await _orderService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _orderService.GetForEditAsync(id);
            if (res == null)
                return NotFound();
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await _orderService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _orderService.GetForEditAsync(id);
            if (res == null)
                return NotFound();
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order ID.");

            await _orderService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
