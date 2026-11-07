using Microsoft.AspNetCore.Mvc;
using SmartInventory.Application.Dto.Category;
using SmartInventory.Application.Service.Interface;
using System.Net.WebSockets;

namespace SmartInventory.WebApi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categroyService;
        public CategoryController(ICategoryService category)
        {
            _categroyService = category;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _categroyService.GetAllAsync();
            return View(res);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var res = await _categroyService.GetByIdAsync(id);
            return View(res);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await _categroyService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }
       public async Task<IActionResult> Delete(int id)
        {
            var res = await _categroyService.GetByIdAsync(id);
            if (res == null)
                return NotFound();
            return View(res);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _categroyService.GetForEditAsync(id);
            if (res == null)
                return NotFound();
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return View();
            await _categroyService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categroyService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
