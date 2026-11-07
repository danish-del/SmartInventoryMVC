using SmartInventory.Application.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ResponseProductDto>> GetAllAsync();
        Task<ResponseProductDto> GetByIdAsync(int id);
        Task<UpdateProductDto> GetEditForAsync(int id);
        Task AddAsync(CreateProductDto dto);
        Task<bool> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> Delete(int id);
    }
}
