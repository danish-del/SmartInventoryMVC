using SmartInventory.Application.Dto.Order;
using SmartInventory.Application.Repository.Interface;
using SmartInventory.Application.Service.Interface;
using SmartInventory.Domain.Model;

namespace SmartInventory.Insfrastructure.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        public OrderService(IGenericRepository<Order> OrderRepo)
        {
            _orderRepo = OrderRepo;
        }
        public async Task<IEnumerable<ResponseOrderDto>> GetAllOrderAsync()
        {
            var entity = await _orderRepo.GetAllAsync();
            return entity.Select(x => new ResponseOrderDto
            {
                OrderId = x.OrderId,
                OrderNumber = x.OrderNumber,
                CustomerId = x.CustomerId,
                OrderDate = x.OrderDate,
                TotalAmount = x.TotalAmount,
                Status = x.Status
            });
        }
        public async Task<ResponseOrderDto?> GetOrderByIdAsync(int id)
        {
            var entity = await _orderRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Order with Id {id} not found!");
            return new ResponseOrderDto
            {
                OrderId = entity.OrderId,
                OrderNumber = entity.OrderNumber,
                CustomerId = entity.CustomerId,
                OrderDate = entity.OrderDate,
                TotalAmount = entity.TotalAmount,
                Status = entity.Status
            };
        }
        public async Task CreateAsync(CreateOrderDto dto)
        {
            var entity = new Order
            {
                OrderNumber = dto.OrderNumber,
                CustomerId = dto.CustomerId,
                OrderDate = dto.OrderDate,
                TotalAmount = dto.TotalAmount,
                Status = dto.Status
            };
            await _orderRepo.AddAsync(entity);
            await _orderRepo.SaveChangesAsync();
        }
        public async Task<UpdateOrderDto> GetForEditAsync(int id)
        {
            var entity = await _orderRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Order with ID {id} not found!");
            return new UpdateOrderDto
            {
                OrderNumber = entity.OrderNumber,
                CustomerId  = entity.CustomerId,
                OrderDate   = entity.OrderDate,
                TotalAmount = entity.TotalAmount,
                Status = entity.Status
            };
        }
        public async Task<bool> UpdateAsync(int id,UpdateOrderDto dto)
        {
            var entity = await _orderRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Order with ID {id} not found!");
            entity.CustomerId = dto.CustomerId;
            entity.OrderDate = dto.OrderDate;
            entity.TotalAmount = dto.TotalAmount;
            entity.Status = dto.Status;
            await _orderRepo.UpdateAsync(entity);
            await _orderRepo.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _orderRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Order with ID {id} not found!");
            await _orderRepo.DeleteAsync(id);
            await _orderRepo.SaveChangesAsync();
            return true;
        }
    }
}
