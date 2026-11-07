using SmartInventory.Application.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Service.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<ResponseCustomerDto>> GetAllAsync();
        Task<ResponseCustomerDto> GetForEditAsyync(int id);
        Task<UpdateCustomerDto> GetForEditAsync(int id);
        Task AddAsync(CreateCustomerDto dto);
        Task<bool> UpdateAsync(int id,UpdateCustomerDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
