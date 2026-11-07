 using Microsoft.AspNetCore.Mvc;
using SmartInventory.Application.Dto.Customer;
using SmartInventory.Application.Service.Interface;
using SmartInventory.Domain.Model;

namespace SmartInventory.WebApi.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService CustomerService)
        {
            _customerService = CustomerService;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _customerService.GetAllAsync();
            return View(res);
        }
        public async Task<IActionResult> Details(int id)
        {
            var res = await _customerService.GetForEditAsyync(id);
            return View(res);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CreateCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await _customerService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _customerService.GetForEditAsyync(id);
            if (res == null)
                return NotFound();
            return View(res);
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,UpdateCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await _customerService.UpdateAsync(id,dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _customerService.GetForEditAsyync(id);
            if (res == null)
                return NotFound();
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!ModelState.IsValid)
                return View();
            await _customerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

