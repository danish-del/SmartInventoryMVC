using SmartInventory.Application.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Service.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<ResponseCategoryDto>> GetAllAsync();
        Task<ResponseCategoryDto?> GetByIdAsync(int id);
        Task<UpdateCategoryDto?> GetForEditAsync(int id);
        Task AddAsync(CreateCategoryDto dto);
        Task<bool> UpdateAsync(int id, UpdateCategoryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
