using SmartInventory.Application.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<ResponseOrderDto>> GetAllOrderAsync();
        Task<UpdateOrderDto> GetForEditAsync(int id);
        Task<ResponseOrderDto?> GetOrderByIdAsync(int id);
        Task CreateAsync(CreateOrderDto dto);
        Task<bool> UpdateAsync(int id, UpdateOrderDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
