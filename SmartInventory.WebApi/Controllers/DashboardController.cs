using Microsoft.AspNetCore.Mvc;
using SmartInventory.Application.Repository.Interface;
using SmartInventory.Domain.Model;

namespace SmartInventory.WebApi.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Product> _productRepo;
        public DashboardController(IGenericRepository<Category> CategoryRepo,
            IGenericRepository<Customer> CustomerRepo, IGenericRepository<Order> OrderRepo,
            IGenericRepository<Product> ProductRepo)
        {
            _categoryRepo = CategoryRepo;
            _customerRepo = CustomerRepo;
            _orderRepo = OrderRepo;
            _productRepo = ProductRepo;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _categoryRepo.GetAllAsync();
            var customer = await _customerRepo.GetAllAsync();
            var order = await _orderRepo.GetAllAsync();
            var product = await _productRepo.GetAllAsync();

            ViewBag.CategoryCount = category.Count();
            ViewBag.CustomerCount = customer.Count();
            ViewBag.OrderCount = order.Count();
            ViewBag.ProductCount = product.Count();


            return View();
        }
    }
}
